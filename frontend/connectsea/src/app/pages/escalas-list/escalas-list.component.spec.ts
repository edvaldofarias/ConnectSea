import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EscalasListComponent } from './escalas-list.component';

describe('EscalasListComponent', () => {
  let component: EscalasListComponent;
  let fixture: ComponentFixture<EscalasListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EscalasListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EscalasListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
