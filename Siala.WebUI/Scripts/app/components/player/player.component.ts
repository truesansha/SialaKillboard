import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

import { PlayerService } from './player.service';

import { PlayerItem } from './PlayerItem';
import { KillListItem } from '../killList/KillListItem';

@Component({
    selector: 'player',
    templateUrl: 'player.component.html'
})

export class PlayerComponent implements OnInit {
    item: PlayerItem;
    killItems: KillListItem[];
    deathItems: KillListItem[];
    id: number;
    constructor(private playerService: PlayerService, private router: Router, private activatedRoute: ActivatedRoute) {
    }

    ngOnInit() {
        this.activatedRoute.params.subscribe((params: Params) => {
            this.id = params['id'];
            this.playerService.getPlayer(this.id).subscribe(item => this.item = item);
            this.playerService.getPlayerKills(this.id, 1).subscribe(items => this.killItems = items);
            this.playerService.getPlayerDeaths(this.id, 1).subscribe(items => this.deathItems = items);
        });
    }
}