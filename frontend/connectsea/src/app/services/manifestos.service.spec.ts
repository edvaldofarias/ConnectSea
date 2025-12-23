import { TestBed } from '@angular/core/testing';

import { ManifestosService } from './manifestos.service';

describe('ManifestosService', () => {
  let service: ManifestosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ManifestosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
