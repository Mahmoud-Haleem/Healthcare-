

import { EntityDto } from '@abp/ng.core';

export class LockupsDto extends EntityDto {
  country: any[];
  state: any[];
  city: any[];
  doctorSpecialty: any[];
  doctorTitle: any[];

  constructor(initialValues: Partial<LockupsDto> = {}) {
    super(initialValues);
  }
}
