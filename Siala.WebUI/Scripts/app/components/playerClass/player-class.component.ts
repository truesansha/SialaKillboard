import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

import { PlayerClassItem } from './PlayerClassItem';
import { PlayerClassService } from './player-class.service';

import './player-class.component.less';

@Component({
    selector: 'player-class',
    templateUrl: 'player-class.component.html'
})

export class PlayerClassComponent implements OnInit {
    item: PlayerClassItem;
    id: number;
    constructor(private playerClassService: PlayerClassService, private router: Router, private activatedRoute: ActivatedRoute) {
    }

    ngOnInit() {
        this.activatedRoute.params.subscribe((params: Params) => {
            this.id = params['id'];
            this.playerClassService.getClass(this.id).subscribe(item => this.item = item);
        });
    }
}