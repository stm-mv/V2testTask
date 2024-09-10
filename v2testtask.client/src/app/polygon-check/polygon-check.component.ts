import { Component, AfterViewInit, ElementRef, Renderer2, ViewChild, HostListener } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormControl, FormGroup, Validators, ReactiveFormsModule, FormsModule } from '@angular/forms';
import { Point, Polygon } from './Interfaces/Polygons';


//form: FormGroup = new FormGroup({
//  "polygonPoints": new FormControl(),
//  "pointInput": new FormControl()
//});

@Component({
  selector: 'app-polygon-drawer',
  templateUrl: './polygon-check.component.html',
  styleUrls: ['./polygon-check.component.css']
})
export class PolygonCheckComponent implements AfterViewInit {
  @ViewChild('myCanvas', { static: true }) canvas: ElementRef;
  context: CanvasRenderingContext2D;
  drawing = false;
  drawingPolygon = false;
  drawingPoint = false;
  polygon: Point[] = [];

  ngAfterViewInit() {
    const canvas = this.canvas.nativeElement;
    this.context = canvas.getContext('2d');

    canvas.onmousedown = (e: MouseEvent) => {
      if (this.drawingPolygon) {
        this.polygon.push({
          x: e.clientX - canvas.offsetLeft,
          y: e.clientY - canvas.offsetTop,
        });
        this.drawing = true;
      }
      else if (this.drawingPoint) {
        return;
      }
    };

    canvas.onmousemove = (e: MouseEvent) => {
      if (!this.drawing) return;
      if (this.drawingPolygon) {
        this.polygon.push({
          x: e.clientX - canvas.offsetLeft,
          y: e.clientY - canvas.offsetTop,
        });
        this.drawPolygon();
      }
    };

    canvas.onmouseup = () => {
      this.drawing = false;
    };
  }

  drawPolygon() {
    this.context.clearRect(
      0,
      0,
      this.canvas.nativeElement.width,
      this.canvas.nativeElement.height
    );
    this.context.beginPath();
    this.context.moveTo(this.polygon[0].x, this.polygon[0].y);

    for (let i = 1; i < this.polygon.length; i++) {
      this.context.lineTo(this.polygon[i].x, this.polygon[i].y);
    }
    this.context.closePath();
    this.context.stroke();
  }

  startDrawingPolygon() {
    this.drawingPolygon = true;
    this.drawingPoint = false;
  }

  startDrawingPoint() {
    console.log(1);
    this.drawingPoint = true;
    this.drawingPolygon = false;
  }

  clearCanvas() {
    this.context.clearRect(
      0,
      0,
      this.canvas.nativeElement.width,
      this.canvas.nativeElement.height
    );
    this.polygon = [];
  //  this.point = { x: 0, y: 0 };
  }

}
