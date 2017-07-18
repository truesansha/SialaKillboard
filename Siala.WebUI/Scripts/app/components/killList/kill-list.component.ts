import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { KillListItem } from './KillListItem';
import { KillListService } from './kill-list.service';

import './kill-list.component.less';

@Component({
    selector: 'kill-list',
    templateUrl: 'kill-list.component.html'
})

export class KillListComponent implements OnInit {
    items: KillListItem[];
    prevPageNum: number;
    nextPageNum: number;
    constructor(private killListService: KillListService,
        private router: Router) {
        this.prevPageNum = 1;
        this.nextPageNum = 2;
    }

    ngOnInit() {
        this.killListService.getList(1).subscribe(items => this.items = items);
    }

    prevPage(page: number) {
        this.prevPageNum -= 1;
        if (this.prevPageNum < 1) {
            this.prevPageNum = 1;
        }
        this.nextPageNum -= 1;
        if (this.nextPageNum < 2) {
            this.nextPageNum = 2;
        }

        this.killListService.getList(page).subscribe(items => this.items = items);
    }

    nextPage(page: number) {
        this.prevPageNum += 1;
        if (this.prevPageNum > 9) {
            this.prevPageNum = 9;
        }
        this.nextPageNum += 1;
        if (this.nextPageNum > 10) {
            this.nextPageNum = 10;
        }
        this.killListService.getList(page).subscribe(items => this.items = items);
    }
}