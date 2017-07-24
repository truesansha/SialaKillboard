import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import { PlayerClassItem } from './PlayerClassItem';

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
}