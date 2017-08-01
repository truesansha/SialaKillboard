import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

import './kill-list.component.css'
import { KillListItem } from './KillListItem';

@Component({
    selector: 'kill-list',
    inputs: ['items'],
    templateUrl: 'kill-list.component.html'
})

export class KillListComponent {
    items: KillListItem[];
}