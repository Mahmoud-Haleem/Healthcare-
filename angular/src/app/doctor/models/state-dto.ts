
import { CountryDto } from './country-dto';

import { EntityDto } from '@abp/ng.core';

export class StateDto extends EntityDto<number> {
  name: string;
  country: any;
  id: number;

  constructor(initialValues: Partial<StateDto> = {}) {
    super(initialValues);
  }
}
