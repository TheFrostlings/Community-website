import { Component, OnInit } from '@angular/core';
import { TwitchService } from '../../services/twitch.service';
import { NgClass } from '@angular/common';

@Component({
    selector: 'app-twitch',
    templateUrl: './twitch.component.html',
    styleUrls: ['./twitch.component.scss']
})
export class TwitchComponent implements OnInit {

    twitch : Object;
    chatLink : String;

    getTwitchLink(twitchObj) : any {
        let link = 'https://player.twitch.tv/?channel='+twitchObj;
        return link;
    }
    getTwitchChatLink(twitchObj) : any {
        let chatLink = 'https://www.twitch.tv/'+twitchObj+'/chat?popout=';
        return chatLink;
    }
    onChange(twitchObj) {
        this.chatLink = 'https://www.twitch.tv/'+twitchObj+'/chat?popout=';
    }

    constructor(private twitchService: TwitchService) { }

    ngOnInit(): void {
        this.twitchService.getTwitchNames()
            .subscribe(res => {
                const response: any = res;
                this.twitch = response.data;
                this.chatLink = 'https://www.twitch.tv/'+this.twitch[0].name+'/chat?popout=';
            });
    }

}
