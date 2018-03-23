import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class ServerService {
    mockedApi = '../../assets/data/server.json';
    arkServerApi = 'https://api.battlemetrics.com/servers/2063036';
    getServer () {
        return this.http.get(this.arkServerApi);
    }
    constructor(public http: HttpClient) { }

}
