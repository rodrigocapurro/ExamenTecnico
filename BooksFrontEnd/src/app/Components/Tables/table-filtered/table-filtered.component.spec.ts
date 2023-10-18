import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TableFilteredComponent } from './table-filtered.component';

describe('TableFilteredComponent', () => {
  let component: TableFilteredComponent;
  let fixture: ComponentFixture<TableFilteredComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TableFilteredComponent]
    });
    fixture = TestBed.createComponent(TableFilteredComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
