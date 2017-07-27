import { NgModule, ErrorHandler } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpModule } from '@angular/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import 'rxjs/Rx';

import { SnotifyModule, SnotifyService } from 'ng-snotify';

import { AppComponent } from './components/app/app.component';
import { HomeComponent } from './components/home/home.component';
import { PageNotFoundComponent } from './components/errors/page-not-found.component';
import { SummaryComponent } from './components/summary/summary.component';
import { KillListComponent } from './components/killList/kill-list.component';
import { KillComponent } from './components/kill/kill.component';
import { PlayerComponent } from './components/player/player.component';
import { PlayerClassComponent } from './components/playerClass/player-class.component';
import { LocationComponent } from './components/location/location.component';
import { FactionComponent } from './components/faction/faction.component';

import { HomeService } from './components/home/home.service';
import { SummaryService } from './components/summary/summary.service';
import { KillService } from './components/kill/kill.service';
import { PlayerService } from './components/player/player.service';
import { PlayerClassService } from './components/playerClass/player-class.service';
import { LocationService } from './components/location/location.service';
import { FactionService } from './components/faction/faction.service';

import { AppRouting } from './routing/app.routing';
import { AppErrorHandler } from './app.errorhandler';
import { ErrorService } from './services/error.service';

@NgModule({
    // directives, components, and pipes
    declarations: [
        AppComponent,
        HomeComponent,
        SummaryComponent,
        KillListComponent,
        KillComponent,
        PlayerComponent,
        PlayerClassComponent,
        LocationComponent,
        FactionComponent,
        PageNotFoundComponent
    ],
    // modules
    imports: [
        AppRouting,
        BrowserModule,
        BrowserAnimationsModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule,
        SnotifyModule
    ],
    // providers
    providers: [
        HomeService,
        SummaryService,
        KillService,
        PlayerService,
        PlayerClassService,
        LocationService,
        FactionService,
        { provide: ErrorHandler, useClass: AppErrorHandler },
        ErrorService,
        SnotifyService
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule { }