import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

import { FactionItem } from './FactionItem';

import { FactionService } from './faction.service';
import { KillListItem } from '../killList/KillListItem';

import './faction.component.less';


@Component({
    selector: 'faction',
    templateUrl: 'faction.component.html'
})

export class FactionComponent implements OnInit {
    item: FactionItem;
    killItems: KillListItem[];
    deathItems: KillListItem[];
    id: number;
    constructor(private factionService: FactionService, private router: Router, private activatedRoute: ActivatedRoute) {
    }

    ngOnInit() {
        this.activatedRoute.params.subscribe((params: Params) => {
            this.id = params['id'];
            this.factionService.getFaction(this.id).subscribe(item => this.item = item);
            this.factionService.getFactionKills(this.id, 1).subscribe(items => this.killItems = items);
            this.factionService.getFactionDeaths(this.id, 1).subscribe(items => this.deathItems = items);
        });
    }
}