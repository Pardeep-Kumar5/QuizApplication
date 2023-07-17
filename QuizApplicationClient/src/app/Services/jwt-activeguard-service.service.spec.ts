import { TestBed } from '@angular/core/testing';

import { JwtActiveguardServiceService } from './jwt-activeguard-service.service';

describe('JwtActiveguardServiceService', () => {
  let service: JwtActiveguardServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(JwtActiveguardServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
