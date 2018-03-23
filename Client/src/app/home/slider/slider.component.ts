import { Component, OnInit, Input } from '@angular/core';
import { SliderService } from '../../services/slider.service';

import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation } from 'ngx-gallery';

@Component({
    selector: 'app-slider',
    templateUrl: './slider.component.html',
    styleUrls: ['./slider.component.scss']
})
export class SliderComponent implements OnInit {

    constructor(private sliderService: SliderService) {  }
    slides: Object;
    galleryOptions: NgxGalleryOptions[];
    galleryImages: NgxGalleryImage[];

    ngOnInit(): void {

        this.galleryOptions =
        [
            {
                width: '90%',
                height: '40vw',
                thumbnailsPercent: 17,
                thumbnailsColumns: 5,
                imageAnimation: NgxGalleryAnimation.Slide,
                previewDescription: false,
                preview: false,
                imageAutoPlay : true,
                imageAutoPlayInterval: 10000,
                imageAutoPlayPauseOnHover: true,
                thumbnails: true
            },
            // max-width 800
            {
                breakpoint: 800,
                height: '50vw',
                imagePercent: 80,
                thumbnailsPercent: 20,
                thumbnailsMargin: 20,
                thumbnailMargin: 20
            },
            // max-width 400
            {
                breakpoint: 400,
                height: '70vw'
            }
        ];
        this.sliderService.getImages()
            .subscribe(res => {
                const response: any = res;
                this.galleryImages = response.slides;
            });
    }
}
