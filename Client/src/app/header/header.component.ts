import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

    constructor() {
        var vm;
        vm = this;
        vm.imageLogoPath = `assets/images/logo.png`;
    }

    ngOnInit() {
    }

}
