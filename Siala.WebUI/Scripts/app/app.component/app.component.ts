import { Component } from '@angular/core';
import { Router } from '@angular/router';
//import { AuthService } from "./auth.service";

import './app.component.less';
import '../../less/style.less';

@Component({
    selector: 'siala-killboard',
    templateUrl: 'app.component.html'
})

export class AppComponent {
    title = 'Siala Killboard';

    //constructor(public router: Router) { }

    //isActive(data: any[]): boolean {
    //    return this.router.isActive(this.router.createUrlTree(data), true);
    //}
}