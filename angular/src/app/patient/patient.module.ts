import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { PatientRoutingModule } from './patient-routing.module';
import { PatientComponent } from './patient.component';
import { NgbDatepickerModule} from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [PatientComponent],
  imports: [
    SharedModule,
    PatientRoutingModule,
    NgbDatepickerModule
  ]
})
export class PatientModule { }
