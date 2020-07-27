import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/',
        name: '::Menu:DoctorManagement',
        iconClass: 'fas fa-stethoscope',
        order: 2,
        layout: eLayoutType.application,
      },
      {
        path: '/doctors',
        name: '::Menu:Doctor',
        iconClass: 'fas fa-user-md',
        order: 2,
        parentName: '::Menu:DoctorManagement',
        layout: eLayoutType.application,
        requiredPolicy: 'Healthcare.Doctors',
      },
      {
        path: '/patients',
        name: '::Menu:Patient',
        iconClass: 'fas fa-user-md',
        parentName: '::Menu:DoctorManagement',
        layout: eLayoutType.application,
        requiredPolicy: 'Healthcare.Patients',
      }
    ]);
  };
}
