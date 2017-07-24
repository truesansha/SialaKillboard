import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

import { FactionItem } from './FactionItem';
import { FactionService } from './faction.service';

import './faction.component.less';

@Component({
    selector: 'faction',
    templateUrl: 'faction.component.html'
})

export class FactionComponent implements OnInit {
    item: FactionItem;
    id: number;
    constructor(private factionService: FactionService, private router: Router, private activatedRoute: ActivatedRoute) {
    }

    ngOnInit() {
        this.activatedRoute.params.subscribe((params: Params) => {
            this.id = params['id'];
            this.factionService.getFaction(this.id).subscribe(item => this.item = item);
        });
    }
}