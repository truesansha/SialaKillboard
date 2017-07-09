import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from '../components/home/home.component';
import { PageNotFoundComponent } from '../components/errors/page-not-found.component';

const appRoutes: Routes = [
    {
        path: '',
        component: HomeComponent
    },
    {
        path: 'home',
        redirectTo: ''
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