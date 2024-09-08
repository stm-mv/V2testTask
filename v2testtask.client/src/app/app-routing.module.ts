import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PolygonCheckComponent } from './polygon-check/polygon-check.component';


const routes: Routes = [
  { path: '', redirectTo: '/polygon', pathMatch: 'full' },
  { path: 'polygon', component: PolygonCheckComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
