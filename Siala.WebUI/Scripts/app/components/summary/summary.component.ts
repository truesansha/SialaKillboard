import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { SummaryItem } from './SummaryItem';
import { SummaryService } from './summary.service';

import './summary.component.css'

@Component({
    selector: 'summary',
    templateUrl: 'summary.component.html'
})

export class SummaryComponent {
    items: SummaryItem[];
    constructor(private summaryService: SummaryService,
        private router: Router) {
    }

    ngOnInit() {
        this.summaryService.getSummary().subscribe(items => this.items = items);
    }
}