

import { EntityDto } from '@abp/ng.core';

export class PatientDto extends EntityDto<number> {
  doctorId: number;
  doctorName: string;
  name: string;
  birthDate: string;
  shortDescription: string;
  id: number;

  constructor(initialValues: Partial<PatientDto> = {}) {
    super(initialValues);
  }
}
