import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import { FactionItem } from './FactionItem';

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
}