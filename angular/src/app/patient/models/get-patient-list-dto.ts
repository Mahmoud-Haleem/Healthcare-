

import { PagedAndSortedResultRequestDto } from '@abp/ng.core';

export class GetPatientListDto extends PagedAndSortedResultRequestDto {
  filter: string;
  sorting: string;
  skipCount: number;
  maxResultCount: number;

  constructor(initialValues: Partial<GetPatientListDto> = {}) {
    super(initialValues);
  }
}
