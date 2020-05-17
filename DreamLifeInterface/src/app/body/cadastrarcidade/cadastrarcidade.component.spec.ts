import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastrarcidadeComponent } from './cadastrarcidade.component';

describe('CadastrarcidadeComponent', () => {
  let component: CadastrarcidadeComponent;
  let fixture: ComponentFixture<CadastrarcidadeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadastrarcidadeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastrarcidadeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
