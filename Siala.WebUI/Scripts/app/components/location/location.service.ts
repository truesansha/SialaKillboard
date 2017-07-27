import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import { LocationItem } from './LocationItem';
import { KillListItem } from '../killList/KillListItem';

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

    getLocationKills(id: number, page: number) {
        var url = this.baseUrl + 'LocationKills/';

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