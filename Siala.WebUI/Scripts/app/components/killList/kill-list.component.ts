import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

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
    page: number;
    constructor(private killListService: KillListService, private router: Router, private activatedRoute: ActivatedRoute) {
    }

    ngOnInit() {
        this.activatedRoute.params.subscribe((params: Params) => {
            this.page = params['page'];
            this.setPage(this.page);
            this.killListService.getList(this.page).subscribe(items => this.items = items);
        });
    }

    private setPage(currentPage: number) {
        if (currentPage && currentPage !== undefined && currentPage.toString() !== '') {
            this.prevPageNum = currentPage - 1;
            this.nextPageNum = parseInt(currentPage.toString()) + 1;
            if (currentPage < 3) {
                this.prevPageNum = null;
            }
        } else {
            this.prevPageNum = null;
            this.nextPageNum = 2;
        }
    }
}