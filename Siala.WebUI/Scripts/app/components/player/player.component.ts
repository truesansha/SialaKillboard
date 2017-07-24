import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

import { PlayerItem } from './PlayerItem';
import { PlayerService } from './player.service';

import './player.component.less';

@Component({
    selector: 'player',
    templateUrl: 'player.component.html'
})

export class PlayerComponent implements OnInit {
    item: PlayerItem;
    id: number;
    constructor(private playerService: PlayerService, private router: Router, private activatedRoute: ActivatedRoute) {
    }

    ngOnInit() {
        this.activatedRoute.params.subscribe((params: Params) => {
            this.id = params['id'];
            this.playerService.getPlayer(this.id).subscribe(item => this.item = item);
        });
    }
}