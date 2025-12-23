import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManifestosListComponent } from './manifestos-list.component';

describe('ManifestosListComponent', () => {
  let component: ManifestosListComponent;
  let fixture: ComponentFixture<ManifestosListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ManifestosListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManifestosListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
