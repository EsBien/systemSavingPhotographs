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
  isDisplayCheckBox:boolean=true;
  images: Image[] = [];
  imagesSaveSuccessfully: boolean = false;
  imageNumber: number = 0;
  constructor(private collectionService: CollectionService) {

  }
  //כדי לשמור את כל התמונות האחרונות שנוספו עשיו לאוסף שישמר במערך תמונות
  combineImages()
  {
    this.images=[]
    for (let index = this.imageNumber; index < this.collection.images.length; index++) {
      const image=this.collection.images[index];
      this.images.push(image)
      
    }
  }
  addImage() {
    this.isDisplayImage = this.collection!=null?true:false;
    this.isDisplayCheckBox=true;
   // this.imageNumber = this.collection.images.length + 1;
    this.imagesSaveSuccessfully = false
    this.collection.images.push({
      collectionSymbolization: this.collection?.collectionSymbolization,
      imagePath: `images/${this.collection?.collectionSymbolization}/000${this.collection.images.length + 1}.jpg`,
      imageBackPath: "", imageNumber: this.collection.images.length + 1
    })
    this.combineImages()
    // const image=this.collection.images[this.collection.images.length-1];
    // this.images.push(image)
  }
  displayAllImage()
  {
    console.log("displayAllImage")
    this.isDisplayCheckBox=false;
    this.isDisplayImage = true;
    this.images=this.collection.images
  }
  saveBackPathImage(image: Image) {
    this.images.at(image.imageNumber - 1)!.imageBackPath = image.imageBackPath
    console.log(this.images.at(image.imageNumber - 1))
  }
 
  deleteLastImage() {
    if (this.collection.images?.length)
    {
      
      this.collection.images?.pop()
      this.combineImages()
    }
    
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
          this.imageNumber = this.collection.images.length ;
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
