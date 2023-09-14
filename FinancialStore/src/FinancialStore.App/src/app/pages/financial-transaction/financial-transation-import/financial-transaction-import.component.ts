import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { FinancialTransaction } from '../shared/financial-transaction.model';


@Component({
  selector: 'app-financial-transaction-import',
  templateUrl: './financial-transaction-import.component.html',
  styleUrls: ['./financial-transaction-import.component.css'],
})
export class FinancialTransactionImportComponent {
  constructor(private http: HttpClient
  ) {

  }
  fileContent: any[] = [];
  fileName = '';
  transactions: FinancialTransaction[] = [];

  public ClearData(): void {

    this.fileContent = [];

    this.fileName = '';

    this.transactions = [];
  }

  public onFileSelected(event: any): void {

    const file: File = event.target.files[0];
    const fileReader = new FileReader();

    this.fileName = file.name;

    fileReader.onload = (e) => {
      const fileContent = fileReader.result as string;
      this.processFileContent(fileContent);
    };

    fileReader.readAsText(file);
  }

  private processFileContent(content: string) {
    const lines = content.split('\n');
    this.fileContent = lines.map((line) => {
      let transaction: FinancialTransaction = {};

      if (line.substring(0, 1) !== '') {
        transaction.Type = Number.parseInt(line.substring(0, 1));
        transaction.Date = line.substring(1, 9);
        transaction.Value = line.substring(10, 19);
        transaction.Cpf = line.substring(19, 30);
        transaction.CardNumber = line.substring(30, 42);
        transaction.Hour = line.substring(42, 48);
        transaction.StoreOwner = line.substring(48, 62);
        transaction.StoreName = line.substring(62, 81);

        this.transactions.push(transaction);
      }
    });
  }

  SendData() {
    const jsonData = JSON.stringify(this.transactions);

    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    this.http.post('http://localhost:5213/api/FinancialTransaction', jsonData, { headers }).subscribe(
      (response: any) => {
        console.log('Resposta da API:', response);
      },
      (error: any) => {
        console.error('Erro ao enviar os dados:', error);
      }
    );
  }
}
