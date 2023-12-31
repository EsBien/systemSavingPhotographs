import { Component, Input, EventEmitter, Output } from '@angular/core';
import { Collection } from '../../models/collection';
import { Image } from '../../models/Image';
//לפי הבנתי לדרישות של הפרוייקט אני שומרת את הנתיב לתמונה ולא את התמונה עצמה
@Component({
  selector: 'app-image-tab',
  templateUrl: './image-tab.component.html',
  styleUrl: './image-tab.component.css'
})
export class ImageTabComponent {
  @Input() showImage?: boolean = false;
  @Input() showCheckBox?: boolean = true;
  @Input() lastImageNumber: boolean=false;
  @Input() displyImage!: Image;
 
  @Input() displaySuccessMessage: boolean = false;
  @Output() onDeleteImage: EventEmitter<any> = new EventEmitter();
  @Output() onBackImagePath: EventEmitter<Image> = new EventEmitter();

  showBackImagePathe: boolean = false;
  collectionNumber?: string = "";
  imageBackPath?: string;

  showBackImage(checked: boolean) {
    this.displyImage.imageBackPath = `images/${this.displyImage?.collectionSymbolization}/000${this.displyImage?.imageNumber}xx.jpg`
    this.showBackImagePathe = checked;
    this.onBackImagePath.emit(this.displyImage)
  }
  OnDelete() {
    this.onDeleteImage.emit();
  }


}
