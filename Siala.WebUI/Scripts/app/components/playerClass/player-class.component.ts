import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

import { PlayerClassItem } from './PlayerClassItem';
import { KillListItem } from '../killList/KillListItem';

import { PlayerClassService } from './player-class.service';

@Component({
    selector: 'player-class',
    templateUrl: 'player-class.component.html'
})

export class PlayerClassComponent implements OnInit {
    item: PlayerClassItem;
    killItems: KillListItem[];
    deathItems: KillListItem[];
    id: number;
    constructor(private playerClassService: PlayerClassService, private router: Router, private activatedRoute: ActivatedRoute) {
    }

    ngOnInit() {
        this.activatedRoute.params.subscribe((params: Params) => {
            this.id = params['id'];
            this.playerClassService.getClass(this.id).subscribe(item => this.item = item);
            this.playerClassService.getPlayerClassKills(this.id, 1).subscribe(items => this.killItems = items);
            this.playerClassService.getPlayerClassDeaths(this.id, 1).subscribe(items => this.deathItems = items);
        });
    }
}