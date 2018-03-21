import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LogoMenuComponent } from './logo-menu.component';

describe('LogoMenuComponent', () => {
  let component: LogoMenuComponent;
  let fixture: ComponentFixture<LogoMenuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LogoMenuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LogoMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
