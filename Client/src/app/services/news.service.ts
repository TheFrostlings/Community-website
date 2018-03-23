import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class NewsService {
    mockedApi = '../../assets/data/news.json';
    newsApi = '';
    
    getNews () {
        return this.http.get(this.mockedApi);
    }
    constructor(public http: HttpClient) { }

}
