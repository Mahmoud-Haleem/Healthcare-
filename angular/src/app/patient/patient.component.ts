import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { PatientDto } from './models';
import { PatientService } from './services';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.scss'],
  providers: [ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
})
export class PatientComponent implements OnInit {
  patient = { items: [], totalCount: 0 } as PagedResultDto<PatientDto>;

  isModalOpen = false;

  form: FormGroup;

  selectedPatient = new PatientDto();

  constructor(
    public readonly list: ListService,
    private patientService: PatientService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService
  ) {}

  ngOnInit(): void {
    const patientStreamCreator = (query) => this.patientService.getListByInput(query);

    this.list.hookToQuery(patientStreamCreator).subscribe((response) => {
      this.patient = response;
    });
  }

  createPatient() {
    this.selectedPatient = new PatientDto();
    this.buildForm();
    this.isModalOpen = true;
  }

  editPatient(id: number) {
    this.patientService.getById(id).subscribe((patient) => {
      this.selectedPatient = patient;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  buildForm() {
    this.form = this.fb.group({
      name: [this.selectedPatient.name || '', Validators.required],
      shortDescription: [this.selectedPatient.shortDescription || '', Validators.required],
      birthDate: [
        this.selectedPatient.birthDate ? new Date(this.selectedPatient.birthDate) : null,
        Validators.required,
      ],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    if (this.selectedPatient.id) {
      this.patientService
        .updateByIdAndInput(this.form.value, this.selectedPatient.id)
        .subscribe(() => {
          this.isModalOpen = false;
          this.form.reset();
          this.list.get();
        });
    } else {
      this.patientService.createByInput(this.form.value).subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
      });
    }
  }

  delete(id: number) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure')
        .subscribe((status) => {
          if (status === Confirmation.Status.confirm) {
            this.patientService.deleteById(id).subscribe(() => this.list.get());
          }
	    });
  }
}
