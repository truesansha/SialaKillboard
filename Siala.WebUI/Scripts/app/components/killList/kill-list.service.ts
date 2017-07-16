import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import { KillListItem } from './KillListItem';

@Injectable()
export class KillListService {
    constructor(private http: Http) { }

    private baseUrl = 'api/kills/'; // web api URL
    // calls the [GET] /api/kills/Get Web API method to retrieve kill list
    get() {
        var url = this.baseUrl;
        return this.http.get(url)
            .map(response => <KillListItem[]>response.json());
    }
}