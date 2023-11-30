import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { MatCheckboxModule } from '@angular/material/checkbox';


import { AppRoutingModule } from './app-routing.module';
import { CollectionDisplayComponent } from './components/collection-display/collection-display.component';
import { AppComponent } from './app.component';
import { CollectionInputComponent } from './components/collection-main/collection-main.component';
import { ImageTabComponent } from './components/image-tab/image-tab.component';


@NgModule({
  declarations: [
    AppComponent,
    CollectionInputComponent,
    CollectionDisplayComponent,
    ImageTabComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatSlideToggleModule,
    MatInputModule,
    MatFormFieldModule,
    MatIconModule,
    HttpClientModule, MatCheckboxModule
    //FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent],

})
export class AppModule { }
