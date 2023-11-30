import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-collection-display',
  templateUrl: './collection-display.component.html',
  styleUrl: './collection-display.component.css'
})
export class CollectionDisplayComponent {

  @Input() collectionName?: string;
  displayCollectionName() {
    console.log("colletion name")
  }
}
