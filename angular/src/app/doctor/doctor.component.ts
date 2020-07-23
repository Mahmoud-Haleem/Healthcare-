import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { DoctorDto, GenderTypeEnum, LockupsDto, DoctorSpecialtyDto, DoctorTitleDto, CountryDto, StateDto, CityDto, AddressDto } from './models';
import { DoctorService } from './services';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-doctor',
  templateUrl: './doctor.component.html',
  styleUrls: ['./doctor.component.scss'],
  providers: [ListService],
})
export class DoctorComponent implements OnInit {

  form: FormGroup;
  isModalOpen = false;

  lockups: LockupsDto;
  countries: CountryDto;
  states: StateDto;
  cities: CityDto;
  specialties: DoctorSpecialtyDto;
  titles: DoctorTitleDto;

  doctorList = { items: [], totalCount: 0 } as PagedResultDto<DoctorDto>;
  selectedDoctor = new DoctorDto();
  genderType = GenderTypeEnum;

  genderTypeList = Object.keys(GenderTypeEnum).filter(
    (gender) => typeof this.genderType[gender] === 'number'
  );

  constructor(public readonly list: ListService, private doctorService: DoctorService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    const doctorStreamCreator = (query) => this.doctorService.getListByInput(query);

    this.list.hookToQuery(doctorStreamCreator).subscribe((response) => {
      this.doctorList = response;
    });

    this.doctorService.getLockupsByCountryIdAndStateId().subscribe((lockup) => {
     this.lockups = lockup;
     console.log(this.lockups);
    });
  }

  createDoctor() {
    this.selectedDoctor = new DoctorDto();
    this.buildDoctorForm();
    this.isModalOpen = true;
  }

  editBook(id: number) {
    this.doctorService.getById(id).subscribe((doctor) => {
      this.selectedDoctor = doctor;
      this.buildDoctorForm();
      this.isModalOpen = true;
    });
  }

  buildDoctorForm() {
    this.form = this.formBuilder.group({
      doctorSpecialtyId: [this.selectedDoctor.doctorSpecialtyId || null, Validators.required],
      doctorTitleId: [this.selectedDoctor.doctorTitleId || null, Validators.required],
      name: [this.selectedDoctor.name || '', Validators.required],
      description: [this.selectedDoctor.description || '', Validators.required],
      gender: [this.selectedDoctor.gender || null, Validators.required],
      address: this.buildAddressForm()
    });
  }

  buildAddressForm(): FormGroup { 
    return this.formBuilder.group({
      streetName: [this.selectedDoctor.addressDto?.streetName || 'شارع العليا', Validators.required],
      districtName: [this.selectedDoctor.addressDto?.districtName || 'الياسمين', Validators.required],
      postalcode: [this.selectedDoctor.addressDto?.postalcode || 123, Validators.required],
      buildNumber: [this.selectedDoctor.addressDto?.buildNumber || 124, Validators.required],
      apartmentNumber: [this.selectedDoctor.addressDto?.apartmentNumber || 125, Validators.required],
      cityId: [this.selectedDoctor.addressDto?.cityId || 2, Validators.required]
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedDoctor.id
      ? this.doctorService.updateByIdAndInput(this.form.value, this.selectedDoctor.id)
      : this.doctorService.createByInput(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }
}
