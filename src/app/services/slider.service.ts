import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class SliderService {
    sliderApi = '../../assets/data/slider.json';

    getImages () {
        return this.http.get(this.sliderApi);
    }
    constructor(public http: HttpClient) { }

}
