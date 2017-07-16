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

import { SummaryService } from './components/summary/summary.service';
import { AppRouting } from './routing/app.routing';
import { AppErrorHandler } from './app.errorhandler';
import { ErrorService } from './services/error.service';

@NgModule({
    // directives, components, and pipes
    declarations: [
        AppComponent,
        SummaryComponent,
        HomeComponent,
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
        SummaryService,
        { provide: ErrorHandler, useClass: AppErrorHandler },
        ErrorService,
        SnotifyService
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule { }