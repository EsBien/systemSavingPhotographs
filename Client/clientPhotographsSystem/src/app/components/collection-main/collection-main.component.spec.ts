import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CollectionInputComponent } from './collection-main.component';

describe('CollectionInputComponent', () => {
  let component: CollectionInputComponent;
  let fixture: ComponentFixture<CollectionInputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CollectionInputComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CollectionInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
