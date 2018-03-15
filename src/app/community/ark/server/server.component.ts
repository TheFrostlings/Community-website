import { Component, OnInit } from '@angular/core';
import { ServerService } from '../../../services/server.service';
import { Ark } from '../../../interface/ark';
import { SortOnlinePipe } from '../../../pipes/sort-online.pipe';

@Component({
    selector: 'app-server',
    templateUrl: './server.component.html',
    styleUrls: ['./server.component.scss']
})
export class ServerComponent implements OnInit, OnDestroy {

    server: Ark;
    interval: any;

    constructor(private serverService: ServerService) { }

    updateServerData() {
        this.serverService.getServer()
            .subscribe(res => {
                const response: any = res;
                this.server = response.data;
            });
    }

    ngOnInit(): void {
        this.updateServerData();
        this.interval = setInterval(() => {
            this.updateServerData();
        }, 60000);

    }
    ngOnDestroy(): void {
        clearInterval(this.interval);
    }

}
