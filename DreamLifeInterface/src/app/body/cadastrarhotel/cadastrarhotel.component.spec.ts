import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastrarhotelComponent } from './cadastrarhotel.component';

describe('CadastrarhotelComponent', () => {
  let component: CadastrarhotelComponent;
  let fixture: ComponentFixture<CadastrarhotelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadastrarhotelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastrarhotelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
