

import { EntityDto } from '@abp/ng.core';

export class DoctorSpecialtyDto extends EntityDto<number> {
  name: string;
  id: number;

  constructor(initialValues: Partial<DoctorSpecialtyDto> = {}) {
    super(initialValues);
  }
}
