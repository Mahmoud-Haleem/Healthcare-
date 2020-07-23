
import { DoctorTitleDto } from './doctor-title-dto';
import { DoctorSpecialtyDto } from './doctor-specialty-dto';
import { AddressDto } from './address-dto';

import { EntityDto } from '@abp/ng.core';

export class DoctorDto extends EntityDto<number> {
  name: string;
  description: string;
  gender: any;
  addressId: number;
  doctorSpecialtyId: number;
  doctorTitleId: number;
  addressDto: any;
  doctorSpecialtyDto: any;
  doctorTitleDto: any;
  id: number;

  constructor(initialValues: Partial<DoctorDto> = {}) {
    super(initialValues);
  }
}
