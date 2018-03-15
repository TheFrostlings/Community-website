import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class MemberService {
    mockedApi = '../../assets/data/members.json';
    arkMemberApi = 'https://api.battlemetrics.com/players?filter[servers]=2063036&page[size]=100&include=server&sort=name';
    getMembers () {
        return this.http.get(this.arkMemberApi);
    }
    constructor(public http: HttpClient) { }

}
