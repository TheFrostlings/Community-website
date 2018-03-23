import { Component, OnInit, OnDestroy } from '@angular/core';
import { MemberService } from '../../../services/member.service';
import { Ark } from '../../../interface/ark';
import { SortOnlinePipe } from '../../../pipes/sort-online.pipe';
import { SortNamePipe } from '../../../pipes/sort-name.pipe';

@Component({
        selector: 'app-members',
        templateUrl: './members.component.html',
        styleUrls: ['./members.component.scss']
})
export class MembersComponent implements OnInit, OnDestroy {

    members: Ark;
    interval: any;

    constructor(private memberService: MemberService) {    }

    getTime(seconds) : any {
        let minutes = Math.floor(seconds / 60);
        let hours = Math.floor(minutes / 60);
        seconds = seconds - (minutes * 60);
        minutes = minutes - (hours * 60);

        return (hours+':'+minutes+':'+seconds);
    }
    getColor(online) : any {
        let color = '';
        if(online) {
            color = '#27F929';
        }
        else {
            color = 'darkred';
        }
        return color;
    }
    updateMemberData() {
        this.memberService.getMembers()
            .subscribe(res => {
                const response: any = res;
                this.members = response.data;
            });
    }

    ngOnInit(): void {
        this.updateMemberData();
        this.interval = setInterval(() => {
            this.updateMemberData();
        }, 5000);
    }
    ngOnDestroy(): void {
        clearInterval(this.interval);
    }

}
