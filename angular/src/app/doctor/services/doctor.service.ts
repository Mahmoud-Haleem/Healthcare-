import { RestService , PagedAndSortedResultRequestDto, PagedResultDto} from '@abp/ng.core';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {LockupsDto, CreateUpdateDoctorDto, DoctorDto} from '../models';

@Injectable({providedIn: 'root'})
export class DoctorService {
  apiName = 'Default';

  constructor(private restService: RestService) {}

 getLockupsByCountryIdAndStateId(countryId: number = 0, stateId: number = 0): Observable<LockupsDto> {
   return this.restService.request({ url: '/api/app/doctor/lockups', method: 'GET', params: { countryId, stateId } },{ apiName: this.apiName });
 }
 createByInput(body: CreateUpdateDoctorDto): Observable<DoctorDto> {
   return this.restService.request({ url: '/api/app/doctor', method: 'POST', body },{ apiName: this.apiName });
 }
 updateByIdAndInput(body: CreateUpdateDoctorDto, id: number): Observable<DoctorDto> {
   return this.restService.request({ url: `/api/app/doctor/${id}`, method: 'PUT', body },{ apiName: this.apiName });
 }
 deleteById(id: number): Observable<void> {
   return this.restService.request({ url: `/api/app/doctor/${id}`, method: 'DELETE' },{ apiName: this.apiName });
 }
 getById(id: number): Observable<DoctorDto> {
   return this.restService.request({ url: `/api/app/doctor/${id}`, method: 'GET' },{ apiName: this.apiName });
 }
 getListByInput(params = {} as PagedAndSortedResultRequestDto): Observable<PagedResultDto<DoctorDto>> {
   return this.restService.request({ url: '/api/app/doctor', method: 'GET', params },{ apiName: this.apiName });
 }
}
