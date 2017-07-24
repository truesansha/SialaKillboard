import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import { LocationItem } from './LocationItem';

@Injectable()
export class LocationService {
    constructor(private http: Http) { }

    private baseUrl = 'api/locations/'; // web api URL
    getLocation(id: number) {
        var url = this.baseUrl + '';
        if (id === null || id === undefined) {
            id = 1;
        }
        url += id;
        return this.http.get(url)
            .map(response => <LocationItem>response.json());
    }
}