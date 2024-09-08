import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PolygonCheckComponent } from './polygon-check.component';

describe('PolygonCheckComponent', () => {
  let component: PolygonCheckComponent;
  let fixture: ComponentFixture<PolygonCheckComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PolygonCheckComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PolygonCheckComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
