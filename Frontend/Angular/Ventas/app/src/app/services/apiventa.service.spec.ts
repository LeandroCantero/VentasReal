import { TestBed } from '@angular/core/testing';

import { ApiventaService } from './apiventa.service';

describe('ApiventaService', () => {
  let service: ApiventaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApiventaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
