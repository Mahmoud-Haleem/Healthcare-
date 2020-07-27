
export class CreatePatientDto  {
  name: string;
  birthDate: string;
  shortDescription: string;

  constructor(initialValues: Partial<CreatePatientDto> = {}) {
    if (initialValues) {
      for (const key in initialValues) {
        if (initialValues.hasOwnProperty(key)) {
          this[key] = initialValues[key];
        }
      }
    }
  }
}
