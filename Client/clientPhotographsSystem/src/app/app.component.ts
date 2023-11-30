import { Component } from '@angular/core';
import { CollectionService } from './service/collection.service';
import { Collection } from './models/collection';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  

  constructor(private collectionService: CollectionService) { }

}
