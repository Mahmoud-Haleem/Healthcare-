import { RestService , ListResultDto, PagedResultDto} from '@abp/ng.core';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {CreatePatientDto, PatientDto, DoctorLookupDto, GetPatientListDto, UpdatePatientDto} from '../models';

@Injectable({providedIn: 'root'})
export class PatientService {
  apiName = 'Default';

  constructor(private restService: RestService) {}

 createByInput(body: CreatePatientDto): Observable<PatientDto> {
   return this.restService.request({ url: '/api/app/patient', method: 'POST', body },{ apiName: this.apiName });
 }
 deleteById(id: number): Observable<void> {
   return this.restService.request({ url: `/api/app/patient/${id}`, method: 'DELETE' },{ apiName: this.apiName });
 }
 getById(id: number): Observable<PatientDto> {
   return this.restService.request({ url: `/api/app/patient/${id}`, method: 'GET' },{ apiName: this.apiName });
 }
 getDoctorLookup(): Observable<ListResultDto<DoctorLookupDto>> {
   return this.restService.request({ url: '/api/app/patient/doctorLookup', method: 'GET' },{ apiName: this.apiName });
 }
 getListByInput(params = {} as GetPatientListDto): Observable<PagedResultDto<PatientDto>> {
   return this.restService.request({ url: '/api/app/patient', method: 'GET', params },{ apiName: this.apiName });
 }
 updateByIdAndInput(body: UpdatePatientDto, id: number): Observable<void> {
   return this.restService.request({ url: `/api/app/patient/${id}`, method: 'PUT', body },{ apiName: this.apiName });
 }
}
