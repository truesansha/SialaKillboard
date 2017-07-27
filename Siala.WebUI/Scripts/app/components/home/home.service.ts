import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import { KillListItem } from '../killList/KillListItem';

@Injectable()
export class HomeService {
    constructor(private http: Http) { }

    private baseUrl = 'api/kills/'; // web api URL
    // calls the [GET] /api/kills/Get Web API method to retrieve kill list
    getList(page: number) {
        var url = this.baseUrl + 'list/';
        if (page === null || page === undefined) {
            page = 1;
        }
        url += page;
        return this.http.get(url)
            .map(response => <KillListItem[]>response.json());
    }
}