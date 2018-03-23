import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-social-menu',
    templateUrl: './social-menu.component.html',
    styleUrls: ['./social-menu.component.scss']
})
export class SocialMenuComponent implements OnInit {

    today: number;

    constructor() { }

    getDateToday() {
        this.today = Date.now();
    }
    ngOnInit() {
        this.getDateToday();
    }

}
