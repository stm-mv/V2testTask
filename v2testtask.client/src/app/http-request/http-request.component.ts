import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Point, Polygon } from '../polygon-check/Interfaces/Polygons'
import { CONFIG } from '../app.component';

@Injectable({
  providedIn: 'root'
})
export class RequestService {
  constructor(private http: HttpClient) { }

  checkPoint(polygonPoints: Point[], point: Point) {
    const body = { polygon: polygonPoints, point: point };
    CONFIG.URL
    return this.http.post(`${CONFIG.URL}/Polygon/CheckPointInsidePolygon`, body);
  }

  savePolygon(polygonPoints: Point[], polygonName: string) {
    const body = { points: polygonPoints, name: polygonName };
    return this.http.post(`${CONFIG.URL}/Polygon/SavePolygon`, body);
  }

  getPolygons(): Observable<Polygon[]> {
    return this.http.get<Polygon[]>(`${CONFIG.URL}/Polygon/Polygons`);
  }
}
