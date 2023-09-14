import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadChildren: () =>
      import('./pages/financial-transaction/financial-transaction.module').then((m) => m.FinancialTransactionModule),
  },
  //{
  //  path: 'escolas',
  //  loadChildren: () =>
  //    import('./pages/school/school.module').then((m) => m.SchoolModule),
  //},
  //{
  //  path: 'turmas',
  //  loadChildren: () =>
  //    import('./pages/class/class.module').then((m) => m.ClassModule),
  //},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
