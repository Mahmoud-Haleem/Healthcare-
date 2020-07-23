import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { DoctorRoutingModule } from './doctor-routing.module';
import { DoctorComponent } from './doctor.component';


@NgModule({
  declarations: [DoctorComponent],
  imports: [
    SharedModule,
    DoctorRoutingModule
  ]
})

export class DoctorModule { }
