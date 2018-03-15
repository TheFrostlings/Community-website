import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CsgoComponent } from './ark.component';

describe('CsgoComponent', () => {
  let component: CsgoComponent;
  let fixture: ComponentFixture<CsgoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CsgoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CsgoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
