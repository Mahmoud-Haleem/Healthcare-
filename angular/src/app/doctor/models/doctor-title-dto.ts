

import { EntityDto } from '@abp/ng.core';

export class DoctorTitleDto extends EntityDto<number> {
  name: string;
  id: number;

  constructor(initialValues: Partial<DoctorTitleDto> = {}) {
    super(initialValues);
  }
}
