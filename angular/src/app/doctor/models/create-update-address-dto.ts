

import { EntityDto } from '@abp/ng.core';

export class CreateUpdateAddressDto extends EntityDto<number> {
  streetName: string;
  districtName: string;
  postalcode: number;
  buildNumber: number;
  apartmentNumber: number;
  cityId: number;
  id: number;

  constructor(initialValues: Partial<CreateUpdateAddressDto> = {}) {
    super(initialValues);
  }
}
