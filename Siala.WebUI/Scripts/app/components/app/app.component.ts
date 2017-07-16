import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SnotifyService, SnotifyToast, SnotifyPosition } from 'ng-snotify';
import { ErrorService } from '../../services/error.service'

import './app.component.less';

@Component({
    selector: 'siala-killboard',
    templateUrl: 'app.component.html'
})

export class AppComponent implements OnInit {
    title = 'SIALA KB';

    constructor(public router: Router, private errorService: ErrorService, private snotifyService: SnotifyService) {
        this.errorService.errorRaised$.subscribe(errorText => {
            this.snotifyService.error(errorText, 'Error');
        });
    }

    ngOnInit() {
        this.snotifyService.setConfig({
            timeout: 5000,
            titleMaxLength: 14,
            bodyMaxLength: 40
        }, {
                newOnTop: false,
                position: SnotifyPosition.right_bottom,
                maxHeight: 500
            });
    }

    isActive(data: any[]): boolean {
        return this.router.isActive(this.router.createUrlTree(data), true);
    }
}