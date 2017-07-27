import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

import { KillListItem } from './KillListItem';

import './kill-list.component.less';

@Component({
    selector: 'kill-list',
    inputs: ['items'],
    templateUrl: 'kill-list.component.html'
})

export class KillListComponent {
    items: KillListItem[];
}