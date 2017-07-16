import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { SummaryItem } from './SummaryItem';
import { SummaryService } from './summary.service';

import './summary.component.less';

@Component({
    selector: 'summary',
    templateUrl: 'summary.component.html'
})

export class SummaryComponent {
    item: SummaryItem;
    constructor(private summaryService: SummaryService,
        private router: Router) {
    }

    ngOnInit() {
        this.summaryService.getSummary().subscribe(item => this.item = item);
    }
}