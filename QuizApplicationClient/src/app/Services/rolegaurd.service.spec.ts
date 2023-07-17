import { TestBed } from '@angular/core/testing';

import { RolegaurdService } from './rolegaurd.service';

describe('RolegaurdService', () => {
  let service: RolegaurdService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RolegaurdService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
