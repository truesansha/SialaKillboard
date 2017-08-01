import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

import { KillItem } from './KillItem';
import { KillService } from './kill.service';

@Component({
    selector: 'kill',
    templateUrl: 'kill.component.html'
})

export class KillComponent implements OnInit {
    item: KillItem;
    id: number;
    constructor(private killService: KillService, private router: Router, private activatedRoute: ActivatedRoute) {
    }

    ngOnInit() {
        this.activatedRoute.params.subscribe((params: Params) => {
            this.id = params['id'];
            this.killService.getKill(this.id).subscribe(item => this.item = item);
        });
    }
}