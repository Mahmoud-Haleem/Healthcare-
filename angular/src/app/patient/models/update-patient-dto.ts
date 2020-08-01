
export class UpdatePatientDto  {
  name: string;
  birthDate: string;
  shortDescription: string;
  doctorId: number;

  constructor(initialValues: Partial<UpdatePatientDto> = {}) {
    if (initialValues) {
      for (const key in initialValues) {
        if (initialValues.hasOwnProperty(key)) {
          this[key] = initialValues[key];
        }
      }
    }
  }
}
