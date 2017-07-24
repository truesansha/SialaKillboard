import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import { PlayerItem } from './PlayerItem';

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
}