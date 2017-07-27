import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import { FactionItem } from './FactionItem';
import { KillListItem } from '../killList/KillListItem';

@Injectable()
export class FactionService {
    constructor(private http: Http) { }

    private baseUrl = 'api/factions/'; // web api URL
    getFaction(id: number) {
        var url = this.baseUrl + '';
        if (id === null || id === undefined) {
            id = 1;
        }
        url += id;
        return this.http.get(url)
            .map(response => <FactionItem>response.json());
    }

    getFactionKills(id: number, page: number) {
        var url = this.baseUrl + 'FactionKills/';

        if (id === null || id === undefined) {
            id = 1;
        }

        if (page === null || page === undefined) {
            page = 1;
        }
        url += id;
        url += '/';
        url += page;

        return this.http.get(url)
            .map(response => <KillListItem[]>response.json());

    }

    getFactionDeaths(id: number, page: number) {
        var url = this.baseUrl + 'FactionDeaths/';

        if (id === null || id === undefined) {
            id = 1;
        }

        if (page === null || page === undefined) {
            page = 1;
        }
        url += id;
        url += '/';
        url += page;

        return this.http.get(url)
            .map(response => <KillListItem[]>response.json());

    }
}