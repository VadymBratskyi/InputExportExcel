import { TestBed } from '@angular/core/testing';

import { TerraTimmerService } from './terra-timmer.service';

describe('TerraTimmerService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TerraTimmerService = TestBed.get(TerraTimmerService);
    expect(service).toBeTruthy();
  });
});
