import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    loadChildren: () => import('./home/home.module').then((m) => m.HomeModule),
  },
  {
    path: 'account',
    loadChildren: () =>
      import('@abp/ng.account').then((m) => m.AccountModule.forLazy({ redirectUrl: '/' })),
  },
  {
    path: 'identity',
    loadChildren: () => import('@abp/ng.identity').then((m) => m.IdentityModule.forLazy()),
  },
  {
    path: 'tenant-management',
    loadChildren: () =>
      import('@abp/ng.tenant-management').then((m) => m.TenantManagementModule.forLazy()),
  },
  {
    path: 'setting-management',
    loadChildren: () =>
      import('@abp/ng.setting-management').then((m) => m.SettingManagementModule.forLazy()),
  },
  {
    path: 'doctors',
    loadChildren: () =>
    import('./doctor/doctor.module').then(m => m.DoctorModule)
  },
  { path: 'patients', loadChildren: () => import('./patient/patient.module').then(m => m.PatientModule) },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
