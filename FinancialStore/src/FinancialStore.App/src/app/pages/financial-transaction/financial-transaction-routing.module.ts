import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FinancialTransactionImportComponent } from './financial-transation-import/financial-transaction-import.component';
import { FinancialTransactionListComponent } from './financial-transation-list/financial-transaction-list.component';

const routes: Routes = [
  {
    path: '', component: FinancialTransactionImportComponent
  },
  {
    path: 'list', component: FinancialTransactionListComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FinancialTransactionRoutingModule { }
