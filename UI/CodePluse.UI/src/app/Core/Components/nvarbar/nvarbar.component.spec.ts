import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NvarbarComponent } from './nvarbar.component';

describe('NvarbarComponent', () => {
  let component: NvarbarComponent;
  let fixture: ComponentFixture<NvarbarComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NvarbarComponent]
    });
    fixture = TestBed.createComponent(NvarbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
