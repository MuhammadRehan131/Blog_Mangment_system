import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImageSelectoreComponent } from './image-selectore.component';

describe('ImageSelectoreComponent', () => {
  let component: ImageSelectoreComponent;
  let fixture: ComponentFixture<ImageSelectoreComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ImageSelectoreComponent]
    });
    fixture = TestBed.createComponent(ImageSelectoreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
