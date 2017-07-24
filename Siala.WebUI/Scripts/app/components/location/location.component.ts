import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

import { LocationItem } from './LocationItem';
import { LocationService } from './location.service';

import './location.component.less';

@Component({
    selector: 'location',
    templateUrl: 'location.component.html'
})

export class LocationComponent implements OnInit {
    item: LocationItem;
    id: number;
    constructor(private locationService: LocationService, private router: Router, private activatedRoute: ActivatedRoute) {
    }

    ngOnInit() {
        this.activatedRoute.params.subscribe((params: Params) => {
            this.id = params['id'];
            this.locationService.getLocation(this.id).subscribe(item => this.item = item);
        });
    }
}