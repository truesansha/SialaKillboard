import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from '../components/home/home.component';
import { KillComponent } from '../components/kill/kill.component';
import { PlayerComponent } from '../components/player/player.component';
import { PlayerClassComponent } from '../components/playerClass/player-class.component';
import { LocationComponent } from '../components/location/location.component';
import { FactionComponent } from '../components/faction/faction.component';
import { PageNotFoundComponent } from '../components/errors/page-not-found.component';

const appRoutes: Routes = [
    {
        path: 'home/:page',
        component: HomeComponent
    },
    {
        path: 'home',
        component: HomeComponent
    },
    {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full'
    },
    {
        path: 'kill/:id',
        component: KillComponent
    },
    {
        path: 'player/:id',
        component: PlayerComponent
    },
    {
        path: 'class/:id',
        component: PlayerClassComponent
    },
    {
        path: 'location/:id',
        component: LocationComponent
    },
    {
        path: 'faction/:id',
        component: FactionComponent
    },
    //{
    //    path: 'battles',
    //    component: AboutComponent
    //},
    //{
    //    path: 'stats',
    //    component: LoginComponent
    //},
    //{
    //    path: 'search',
    //    component: ItemDetailEditComponent
    //},
    //{
    //    path: 'maps',
    //    component: ItemDetailViewComponent
    //},
    {
        path: '**',
        component: PageNotFoundComponent
    }
];

export const AppRoutingProviders: any[] = [
];

export const AppRouting: ModuleWithProviders = RouterModule.forRoot(appRoutes);