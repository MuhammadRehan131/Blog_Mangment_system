import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BlogDteailsComponent } from './blog-dteails.component';

describe('BlogDteailsComponent', () => {
  let component: BlogDteailsComponent;
  let fixture: ComponentFixture<BlogDteailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BlogDteailsComponent]
    });
    fixture = TestBed.createComponent(BlogDteailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
