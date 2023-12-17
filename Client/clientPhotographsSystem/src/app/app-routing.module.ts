import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CollectionInputComponent } from './components/collection-main/collection-main.component';
import { CollectionDisplayComponent } from './components/collection-display/collection-display.component';

const routes: Routes = [
  {component:CollectionInputComponent,path:''},
  {component:CollectionDisplayComponent,path:'DisplayComponent'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
