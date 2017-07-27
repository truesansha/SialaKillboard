import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import { PlayerItem } from './PlayerItem';
import { KillListItem } from '../killList/KillListItem';

@Injectable()
export class PlayerService {
    constructor(private http: Http) { }

    private baseUrl = 'api/players/'; // web api URL
    // calls the [GET] /api/kills/Get Web API method to retrieve kill list
    getPlayer(id: number) {
        var url = this.baseUrl;
        if (id === null || id === undefined) {
            id = 1;
        }
        url += id;
        return this.http.get(url)
            .map(response => <PlayerItem>response.json());
    }

    getPlayerKills(id: number, page: number) {
        var url = this.baseUrl + 'PlayerKills/';

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

    getPlayerDeaths(id: number, page: number) {
        var url = this.baseUrl + 'PlayerDeaths/';

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