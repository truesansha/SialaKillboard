import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import { SummaryItem } from './SummaryItem';

@Injectable()
export class SummaryService {
    constructor(private http: Http) { }

    private baseUrl = 'api/summary/'; // web api URL
    // calls the [GET] /api/summary/GetSummary Web API method to retrieve k/d summary information.
    getSummary() {
        var url = this.baseUrl;
        return this.http.get(url)
            .map(response => <SummaryItem[]>response.json());
    }

    private handleError(error: Response) {
        // output errors to the console.
        console.error('LOCAL ERROR');
        return Observable.throw(error);
    }
}