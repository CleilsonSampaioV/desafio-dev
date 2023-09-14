import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FinancialTransactionRoutingModule } from './financial-transaction-routing.module';
import { FinancialTransactionImportComponent } from './financial-transation-import/financial-transaction-import.component';
import { SharedModule } from '../../shared/shared.module';
import { FinancialTransactionListComponent } from './financial-transation-list/financial-transaction-list.component';

@NgModule({
  declarations: [
    FinancialTransactionImportComponent,
    FinancialTransactionListComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    FinancialTransactionRoutingModule,
  ],
})
export class FinancialTransactionModule {}
