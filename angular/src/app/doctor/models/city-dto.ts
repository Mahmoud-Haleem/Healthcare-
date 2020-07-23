
import { StateDto } from './state-dto';

import { EntityDto } from '@abp/ng.core';

export class CityDto extends EntityDto<number> {
  name: string;
  state: any;
  id: number;

  constructor(initialValues: Partial<CityDto> = {}) {
    super(initialValues);
  }
}
