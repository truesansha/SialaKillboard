import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { KillListItem } from './KillListItem';
import { KillListService } from './kill-list.service';

import './kill-list.component.less';

@Component({
    selector: 'kill-list',
    templateUrl: 'kill-list.component.html'
})

export class KillListComponent {
    items: KillListItem[];
    constructor(private killListService: KillListService,
        private router: Router) {
    }

    ngOnInit() {
        this.killListService.get().subscribe(items => this.items = items);
    }
}