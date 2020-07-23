
import { CreateUpdateAddressDto } from './create-update-address-dto';
import { GenderTypeEnum } from './gender-type-enum';

import { EntityDto } from '@abp/ng.core';

export class CreateUpdateDoctorDto extends EntityDto<number> {
  name: string;
  description: string;
  gender: any;
  addressId: number;
  doctorSpecialtyId: number;
  doctorTitleId: number;
  address: any;
  id: number;

  constructor(initialValues: Partial<CreateUpdateDoctorDto> = {}) {
    super(initialValues);
  }
}
