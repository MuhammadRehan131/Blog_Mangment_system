import { TestBed } from '@angular/core/testing';

import { ImgeSelectorService } from './imge-selector.service';

describe('ImgeSelectorService', () => {
  let service: ImgeSelectorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ImgeSelectorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
