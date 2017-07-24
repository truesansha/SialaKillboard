import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import { KillItem } from './KillItem';

@Injectable()
export class KillService {
    constructor(private http: Http) { }

    private baseUrl = 'api/kills/'; // web api URL
    // calls the [GET] /api/kills/Get Web API method to retrieve kill list
    getKill(id: number) {
        var url = this.baseUrl;
        if (id === null || id === undefined) {
            id = 1;
        }
        url += id;
        return this.http.get(url)
            .map(response => <KillItem>response.json());
    }
}