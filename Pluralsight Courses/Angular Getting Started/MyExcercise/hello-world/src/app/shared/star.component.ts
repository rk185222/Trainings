import { Component, Input, OnChanges, Output, SimpleChanges, EventEmitter } from '@angular/core';

@Component({
  selector: 'hw-star',
  templateUrl: './star.component.html',
  styleUrls: ['./star.component.css']
})
export class StarComponent implements OnChanges {

  @Input() rating: number = 4;
  @Output() ratingClicked: EventEmitter<string> = new EventEmitter<string>();
  cropWidth = 75;

  ngOnChanges(changes: SimpleChanges): void {
    this.cropWidth = this.rating * 75 / 5;
  }

  onClick(): void {
    this.ratingClicked.emit(`The rating ${this.rating} was clicked!`);
  }

}
