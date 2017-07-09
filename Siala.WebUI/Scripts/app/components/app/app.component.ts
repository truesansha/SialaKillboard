import { Component } from '@angular/core';
import { Router } from '@angular/router';

import './app.component.less';

@Component({
    selector: 'siala-killboard',
    templateUrl: 'app.component.html'
})

export class AppComponent {
    title = 'SIALA KB';

    constructor(public router: Router) { }

    isActive(data: any[]): boolean {
        return this.router.isActive(this.router.createUrlTree(data), true);
    }
}