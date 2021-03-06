import { DoBootstrap, NgModule, Injector } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterModule } from '@angular/router';


import { AppComponent } from './app.component';
import { LayoutComponent } from './layout/layout.component';
import { SidenavComponent } from './sidenav/sidenav.component';
import { LoginComponent } from './login/login.component';
import { LivechatComponent } from './livechat/livechat.component';
import { GamelistComponent } from './gamelist/gamelist.component';
import { RegisterComponent } from './register/register.component';
import { LeaderboardComponent } from './leaderboard/leaderboard.component';
import { PartygameService } from './services/partygame.service';
import { AuthGuard } from './services/auth.guard';
import { SquareComponent } from './tictactoe/square/square.component';
import { BoardComponent } from './tictactoe/board/board.component';
import { SnakeComponent } from './snake/snake.component';
import { GameFieldComponent } from './snake/game-field/game-field.component';

import { NgxWheelModule } from 'ngx-wheel';
import { MatchComponent } from './match/match.component';
import { BlackjackComponent } from './blackjack/blackjack.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { AboutComponent } from './about/about.component';


@NgModule({
  declarations: [
    AppComponent,
    LayoutComponent,
    SidenavComponent,
    LoginComponent,
    LivechatComponent,
    GamelistComponent,
    RegisterComponent,
    LeaderboardComponent,
    SquareComponent,
    BoardComponent,
    MatchComponent,
    SnakeComponent,
    GameFieldComponent,
    BlackjackComponent,
    UserProfileComponent,
    AboutComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      {path: "Login", component: LoginComponent},
      {path: "Register", component: RegisterComponent},
      {path: 'layout',
        component: LayoutComponent,
        canActivate: [AuthGuard]
      },
      {path: "UserProfile", component: UserProfileComponent},
      {path: "About", component: AboutComponent}
    ]),
    NgbModule,
    NgxWheelModule
  ],
  providers: [PartygameService,AuthGuard],
  bootstrap: [AppComponent]
})

export class AppModule{}
// export class AppModule implements DoBootstrap {

//   constructor(injector: Injector) {
//     const snakeComponent = createCustomElement(SnakeComponent, { injector });
//     customElements.define('ng-snake', snakeComponent);
//   }

//   ngDoBootstrap(){}
// }

