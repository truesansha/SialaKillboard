import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import { PlayerClassItem } from './PlayerClassItem';
import { KillListItem } from '../killList/KillListItem';

@Injectable()
export class PlayerClassService {
    constructor(private http: Http) { }

    private baseUrl = 'api/playerclasses/'; // web api URL
    getClass(id: number) {
        var url = this.baseUrl + '';
        if (id === null || id === undefined) {
            id = 1;
        }
        url += id;
        return this.http.get(url)
            .map(response => <PlayerClassItem>response.json());
    }

    getPlayerClassKills(id: number, page: number) {
        var url = this.baseUrl + 'PlayerClassKills/';

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

    getPlayerClassDeaths(id: number, page: number) {
        var url = this.baseUrl + 'PlayerClassDeaths/';

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