
export class DoctorLookupDto  {
  items: any[];

  constructor(initialValues: Partial<DoctorLookupDto> = {}) {
    if (initialValues) {
      for (const key in initialValues) {
        if (initialValues.hasOwnProperty(key)) {
          this[key] = initialValues[key];
        }
      }
    }
  }
}
