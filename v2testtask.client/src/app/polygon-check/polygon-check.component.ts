import { Component, AfterViewInit, ElementRef, Renderer2, ViewChild, HostListener } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormControl, FormGroup, Validators, ReactiveFormsModule, FormsModule } from '@angular/forms';
import { Point, Polygon } from './Interfaces/Polygons';
import { RequestService } from '../http-request/http-request.component'


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
  polygons: Polygon[] = [];
  point: Point = { x: 0, y: 0 };
  pointCheck: boolean = false;

  constructor(private requestService: RequestService) { }


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
    this.point = { x: 0, y: 0 };
  }

  checkPointInsidePolygon() {
    this.requestService.checkPoint(this.polygon, this.point).subscribe(
      (response) => {
        this.pointCheck = Boolean(response);
        console.log('Is Point inside Polygon checked successfully', response)
      },
      (error) => console.error('Error checking is Point inside Polygon', error)
    );
  }

  savePolygon() {
    let name = "test";
    console.log(name)
    this.requestService.savePolygon(this.polygon, name).subscribe(
      (response: any) => console.log('Polygon saved successfully', response),
      (error) => console.error('Error saving polygon', error)
    );
  }

  onPolygonSelect(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    const selectedPolygonId = selectElement.value;

    const selectedPolygon = this.polygons.find((polygon) => {
      return polygon.id === Number(selectedPolygonId);
    });

    console.log('Selected Polygon:', selectedPolygon);

    if (selectedPolygon) {
      this.drawSelectedPolygon(selectedPolygon);
    } else {
      console.log('Selected Polygon not found');
    }
  }

  drawSelectedPolygon(polygon: Polygon) {
    this.polygon = polygon.points
    this.context.clearRect(0, 0, this.canvas.nativeElement.width, this.canvas.nativeElement.height);

    this.context.beginPath();

    this.context.moveTo(polygon.points[0].x, polygon.points[0].y);
    for (let i = 1; i < polygon.points.length; i++) {
      this.context.lineTo(polygon.points[i].x, polygon.points[i].y);
    }

    this.context.closePath();
    this.context.stroke();
  }
}
