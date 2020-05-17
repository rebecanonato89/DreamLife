import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StatusViagemComponent } from './status-viagem.component';

describe('StatusViagemComponent', () => {
  let component: StatusViagemComponent;
  let fixture: ComponentFixture<StatusViagemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StatusViagemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StatusViagemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
