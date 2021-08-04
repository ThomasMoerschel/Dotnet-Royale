﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PartyGameDL;
using PartyGameModels;
using Xunit;

namespace PartyGameTest
{
    public class RepositoryTesting
    {
        private readonly DbContextOptions<PartyGamesDBContext> _options;
        public RepositoryTesting()
        {
            //is "Filename = Test.db" necessary and where is it pointing?
            _options = new DbContextOptionsBuilder<PartyGamesDBContext>().UseSqlite("Filename = Test.db").Options;
            this.Seed();
        }

        [Fact]
        public void GetAllUsersShouldGetAllUsers()
        {
            using (var context = new PartyGamesDBContext(_options))
            {
                IUserRepository repo = new UserRepository(context);
                List <User> allUsers = repo.GetAllUsers();
                int numOfUsers = allUsers.Count;
                Assert.Equal(2, numOfUsers);
            }
        }
        [Fact]
        public void GetAllGamesShouldGetAllGames()
        {
            using (var context = new PartyGamesDBContext(_options))
            {
                IGameRepository repo = new GameRepository(context);
                List <Games> allGames = repo.GetAllGames();
                int numOfGames = allGames.Count;
                Assert.Equal(2, numOfGames);
            }
        }
        [Fact]
        public void AddingUserShouldAddUser()
        {
            using (var context = new PartyGamesDBContext(_options))
            {
                IUserRepository repo = new UserRepository(context);
                User newUser = new User()
                {
                    Id = 0,
                    UserName = "Test3",
                    Password = "Pass3",
                    IsAdmin = false,
                };
                repo.AddUser(newUser);
                List<User> allUsers = repo.GetAllUsers();
                int numOfUsers = allUsers.Count;
                Assert.Equal(3, numOfUsers);
            }
        }
        [Fact]
        public void GetScoreHistoryByGameIdShouldGetGameScoreHistory()
        {
             using (var context = new PartyGamesDBContext(_options))
            {
                IGameRepository repo = new GameRepository(context);
                List <ScoreHistory> snakeScoreHistory = repo.GetScoreHistoryByGameId(1);
                List <ScoreHistory> blackJackScoreHistory = repo.GetScoreHistoryByGameId(2);
                int numberOfBlackjackScores = blackJackScoreHistory.Count;
                int numberOfSnakeScores = snakeScoreHistory.Count;
                Assert.Equal(2, numberOfSnakeScores);
                Assert.Equal(0, numberOfBlackjackScores);

            }
        }
        [Fact]
        public void GetScoreHistoryByUserIdShouldGetAUsersScoreHistory()
        {
             using (var context = new PartyGamesDBContext(_options))
            {
                IUserRepository repo = new UserRepository(context);
                List <ScoreHistory> UserScoreHistory = repo.GetScoreHistoryByUserId(1);
                int numberOfUserScores = UserScoreHistory.Count;
                Assert.Equal(1, numberOfUserScores);

            }
        }
        [Fact]
        public void GetBlackjackGameStatsByUserIdShouldGetAUsersBlackjackStats()
        {
            using (var context = new PartyGamesDBContext(_options))
            {
                IUserRepository repo = new UserRepository(context);
                Blackjack UserScoreHistory = repo.GetBlackJackGameStatsByUserId(1);
                float UserWinLoss = UserScoreHistory.WinLossRatio;
                Assert.Equal(0.80f, UserWinLoss);
            }
        }
        [Fact]
        public void GetSnakeGameStatsByUserIdShouldGetAUsersSnakeStats()
        {
            using (var context = new PartyGamesDBContext(_options))
            {
                IUserRepository repo = new UserRepository(context);
                Snake UserScoreHistory = repo.GetSnakeGameStatsByUserId(1);
                double UserHighScore = UserScoreHistory.HighScore;
                double UserAvgScore = UserScoreHistory.AvgScore;
                Assert.Equal(20, UserHighScore);
                Assert.Equal(15, UserAvgScore);
            }
        } 
        private void Seed()
        {
            using (var context = new PartyGamesDBContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                
                context.Games.AddRange(
                    new Games
                    {
                        Id = 1,
                        Name = "Test SnakeGame Name",
                        Description = "Snake Description",
                    },
                    new Games
                    {
                        Id = 2,
                        Name = "Test BlackjackGame Name",
                        Description = "BlackJack Description"
                    }
                );
                context.Users.AddRange(
                    new User
                    {
                        Id = 1,
                        UserName = "TestUserName1",
                        Password = "TestPassword1",
                        IsAdmin = true,
                    },
                    new User
                    {
                        Id = 2,
                        UserName = "TestUserName2",
                        Password = "TestPassword2",
                        IsAdmin = false,
                    }
                );
                context.Snakes.AddRange(
                    new Snake
                    {
                        Id = 1,
                        UserId = 1,
                        GamesId = 1,
                        AvgScore = 15,
                        HighScore = 20,
                    },
                    new Snake
                    {
                        Id = 2,
                        UserId = 2,
                        GamesId = 1,
                        AvgScore = 20,
                        HighScore = 30,
                    }
                );
                context.Blackjacks.AddRange(
                    new Blackjack
                    {
                        Id = 1,
                        UserId = 1,
                        GamesId = 2,
                        WinLossRatio = 0.80f,
                    },
                    new Blackjack
                    {
                        Id = 2,
                        UserId = 2,
                        GamesId = 2,
                        WinLossRatio = 1.55f,
                    }
                );
                context.ScoreHistories.AddRange(
                    new ScoreHistory
                    {
                        Id = 1,
                        GameId = 1,
                        UserId = 1,
                        Score = 1500,
                    },
                    new ScoreHistory
                    {
                        Id = 2,
                        GameId = 1,
                        UserId = 2,
                        Score = 1600,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}