import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

import { KillListItem } from '../killList/KillListItem';
import { HomeService } from './home.service';

@Component({
    selector: 'home',
    templateUrl: 'home.component.html'
})

export class HomeComponent implements OnInit {
    items: KillListItem[];
    prevPageNum: number;
    nextPageNum: number;
    page: number;
    constructor(private homeService: HomeService, private router: Router, private activatedRoute: ActivatedRoute) {
    }

    ngOnInit() {
        this.activatedRoute.params.subscribe((params: Params) => {
            this.page = params['page'];
            this.setPage(this.page);
            this.homeService.getList(this.page).subscribe(items => this.items = items);
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