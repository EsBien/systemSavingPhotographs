import { Component, OnInit, Output, EventEmitter, ViewContainerRef } from '@angular/core';
import { CollectionService } from '../../service/collection.service';
import { Observable } from 'rxjs';
import { error } from 'console';
import { Image } from '../../models/Image';
import { Collection } from '../../models/collection';



@Component({
  selector: 'app-collection-main',
  templateUrl: './collection-main.component.html',
  styleUrl: './collection-main.component.css',
})
export class CollectionInputComponent {

 
  title: string = "סריקת אוסף"
  collectionNumber: string = '';
  collectionNameInput = "";
  collection!: Collection;
  isDisplayImage?: boolean = false;
  images: Image[] = [];
  imagesSaveSuccessfully: boolean = false;
  imageNumber: number = 0;
  constructor(private collectionService: CollectionService) {

  }
  addImage() {
    this.isDisplayImage = true;
    this.imageNumber = this.collection.images.length + 1;
    this.imagesSaveSuccessfully = false
    this.collection.images.push({
      collectionSymbolization: this.collection?.collectionSymbolization,
      imagePath: `images/${this.collection?.collectionSymbolization}/000${this.imageNumber}.jpg`,
      imageBackPath: "", imageNumber: this.imageNumber
    })
    const image=this.collection.images[this.collection.images.length-1];
    this.images.push(image)
  }

  saveBackPathImage(image: Image) {
    this.images.at(image.imageNumber - 1)!.imageBackPath = image.imageBackPath
    console.log(this.images.at(image.imageNumber - 1))
  }

  deleteLastImage() {
    if (this.images?.length)
      this.images?.pop()
    else {
      this.isDisplayImage = false //When all images are deleted, save button will not be displayed on the screen
    }
  }
  //this function get the collection from 
  onSubmit(name: string) {
    this.isDisplayImage = false //receiving a new collection DisplayImages will be false
    this.imagesSaveSuccessfully=false
    this.collectionNumber = name
    this.images = [] // clearing out the image list for a new collection
    this.collectionService.getCollectionName(this.collectionNumber)
      .subscribe(
        (data) => {
          console.log(data);
          this.collectionNameInput = data.title;
          this.collection = data
        },
        (error) => {
          console.error(error);
          this.collectionNameInput = "";
        }
      );
  }
  Saveimages() {
    this.collectionService.saveCollection(this.collection)
      .subscribe(
        (data) => { this.imagesSaveSuccessfully = true },
        (error) => { console.log(error) }
      )
  }
}
