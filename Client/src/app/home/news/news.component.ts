import { Component, OnInit, OnDestroy } from '@angular/core';
import { NewsService } from '../../services/news.service';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.scss']
})
export class NewsComponent implements OnInit {

    news: Object;
    interval: any;

    constructor(private newsService: NewsService) { }

    updateNewsData() {
        this.newsService.getNews()
            .subscribe(res => {
                const response: any = res;
                this.news = response.news;
            });
    }

    ngOnInit(): void {
        this.updateNewsData();
        this.interval = setInterval(() => {
            this.updateNewsData();
        }, 60000);

    }
    ngOnDestroy(): void {
        clearInterval(this.interval);
    }

}
