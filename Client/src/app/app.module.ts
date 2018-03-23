import { BrowserModule }        from '@angular/platform-browser';
import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule }     from '@angular/common/http';

import { AppComponent }         from './app.component';

import 'hammerjs';

import { MemberService }        from './services/member.service';
import { ServerService }        from './services/server.service';
import { TwitchService }        from './services/twitch.service';
import { NewsService }          from './services/news.service';


import { HeaderComponent }      from './header/header.component';
import { MenuComponent }        from './header/menu/menu.component';
import { LogoMenuComponent }    from './header/logo-menu/logo-menu.component';
import { SocialMenuComponent }  from './header/social-menu/social-menu.component';

import { LoginComponent }       from './login/login.component';
import { DiscordComponent }     from './home/discord/discord.component';

import { HomeComponent }        from './home/home.component';

import { ArkComponent }         from './community/ark/ark.component';
import { MembersComponent }     from './community/ark/members/members.component';
import { ServerComponent }      from './community/ark/server/server.component';

import { SortOnlinePipe }       from './pipes/sort-online.pipe';
import { SortNamePipe }         from './pipes/sort-name.pipe';
import { SafePipe }             from './pipes/safe.pipe';

import { TwitchComponent }      from './community/twitch/twitch.component';
import { NewsComponent } from './home/news/news.component';


const appRoutes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'home',  component: HomeComponent },
  { path: 'ark', component: ArkComponent },
  { path: 'twitch', component: TwitchComponent },
  { path: '',
    redirectTo: '/login',
    pathMatch: 'full'
  },
  //{ path: '**', component: PageNotFoundComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    MenuComponent,
    LoginComponent,
    HomeComponent,
    MembersComponent,
    ArkComponent,
    SortOnlinePipe,
    ServerComponent,
    SortNamePipe,
    DiscordComponent,
    TwitchComponent,
    SafePipe,
    SocialMenuComponent,
    LogoMenuComponent,
    NewsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(
        appRoutes,
        { enableTracing: false } // <-- debugging purposes only
    )
  ],
  providers: [
        MemberService,
        ServerService,
        TwitchService,
        NewsService
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
