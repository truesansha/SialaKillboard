import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

import { LocationItem } from './LocationItem';
import { KillListItem } from '../killList/KillListItem';

import { LocationService } from './location.service';

@Component({
    selector: 'location',
    templateUrl: 'location.component.html'
})

export class LocationComponent implements OnInit {
    item: LocationItem;
    killItems: KillListItem[];
    id: number;
    constructor(private locationService: LocationService, private router: Router, private activatedRoute: ActivatedRoute) {
    }

    ngOnInit() {
        this.activatedRoute.params.subscribe((params: Params) => {
            this.id = params['id'];
            this.locationService.getLocation(this.id).subscribe(item => this.item = item);
            this.locationService.getLocationKills(this.id, 1).subscribe(items => this.killItems = items);
        });
    }
}