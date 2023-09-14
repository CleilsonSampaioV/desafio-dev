import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { FinancialTransactionSummary } from '../shared/financial-transaction-summary.model';


@Component({
  selector: 'app-financial-transaction-list',
  templateUrl: './financial-transaction-list.component.html',
  styleUrls: ['./financial-transaction-list.component.css'],
})
export class FinancialTransactionListComponent {
  constructor(private http: HttpClient
  ) {

  }

  transactionsSummary?: FtSummary[];

  ngOnInit() {
    this.getStoresSummaary();
  }

  getStoresSummaary() {
    this.getStoresData().subscribe(
      (data:any[]) => {
        this.transactionsSummary = data;

        this.transactionsSummary.forEach((element) => console.log(element));
        let a = '';
      },
      (error) => {
        console.error('Erro ao obter os dados:', error);
      }
    );
  }

  getStoresData(): Observable<any> {
    return this.http.get<any[]>("http://localhost:5213/api/FinancialTransaction/");
  }
}

interface FtSummary {
  storeName?: string,
  value?: Number
}
