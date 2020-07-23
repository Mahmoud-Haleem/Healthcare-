

import { EntityDto } from '@abp/ng.core';

export class CountryDto extends EntityDto<number> {
  name: string;
  id: number;

  constructor(initialValues: Partial<CountryDto> = {}) {
    super(initialValues);
  }
}
