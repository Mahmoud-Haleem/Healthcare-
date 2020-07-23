
import { CityDto } from './city-dto';

import { EntityDto } from '@abp/ng.core';

export class AddressDto extends EntityDto<number> {
  streetName: string;
  districtName: string;
  postalcode: number;
  buildNumber: number;
  apartmentNumber: number;
  cityId: number;
  city: any;
  id: number;

  constructor(initialValues: Partial<AddressDto> = {}) {
    super(initialValues);
  }
}
