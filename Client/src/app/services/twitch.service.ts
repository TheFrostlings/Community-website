import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class TwitchService {
    mockedApi = '../../assets/data/twitch.json';
    getTwitchNames () {
        return this.http.get(this.mockedApi);
    }
    constructor(public http: HttpClient) { }

}
