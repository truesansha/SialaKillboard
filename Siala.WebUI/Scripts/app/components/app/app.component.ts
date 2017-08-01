import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SnotifyService, SnotifyToast, SnotifyPosition } from 'ng-snotify';
import { ErrorService } from '../../services/error.service'

import { MenuItem } from 'primeng/primeng';

import './app.component.css'
import '../../../assets/css/styles.css';
import '../../../../node_modules/primeng/resources/primeng.min.css';
import '../../../../node_modules/font-awesome/css/font-awesome.min.css';

@Component({
    selector: 'siala-killboard',
    templateUrl: 'app.component.html'
})

export class AppComponent implements OnInit {
    items: MenuItem[];

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

        this.items = [
            {
                label: 'Home', icon: 'fa-angle-right', routerLink: ['home']
            },
            {
                label: 'Battles', icon: 'fa-angle-right', routerLink: ['battles']
            },
            {
                label: 'Stats', icon: 'fa-angle-right', routerLink: ['stats']
            },
            {
                label: 'Search', icon: 'fa-angle-right', routerLink: ['search']
            },
            {
                label: 'Forum', icon: 'fa-angle-right', url: 'http://siala.kiev.ua/index.php?'
            },
            {
                label: 'Maps', icon: 'fa-angle-right', routerLink: ['maps']
            }
        ];
    }

    isActive(data: any[]): boolean {
        return this.router.isActive(this.router.createUrlTree(data), true);
    }
}