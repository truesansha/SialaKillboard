import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import 'rxjs/Rx';

//import { AboutComponent } from './about.component';
import { AppComponent } from './components/app/app.component';
import { HomeComponent } from './components/home/home.component';
import { PageNotFoundComponent } from './components/errors/page-not-found.component';
import { SummaryComponent } from './components/summary/summary.component';
//import { ItemDetailEditComponent } from './item-detail-edit.component';
//import { ItemDetailViewComponent } from './item-detail-view.component';
//import { LoginComponent } from './login.component';
//import { PageNotFoundComponent } from './page-not-found.component';
import { AppRouting } from './routing/app.routing';
import { SummaryService } from './services/summary.service';
//import { AuthService } from './auth.service';
//import { AuthHttp } from './auth.http';

@NgModule({
    // directives, components, and pipes
    declarations: [
        AppComponent,
        SummaryComponent,
        //ItemDetailEditComponent,
        //ItemDetailViewComponent,
        //AboutComponent,
        HomeComponent,
        //LoginComponent,
        PageNotFoundComponent
    ],
    // modules
    imports: [
        BrowserModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule,
        AppRouting
    ],
    // providers
    providers: [
        SummaryService
        //AuthService,
        //AuthHttp
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule { }