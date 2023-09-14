import { BaseResourceModel } from '../../../shared/models/base-resource.model';

export class FinancialTransactionSummary extends BaseResourceModel {
  constructor(
    public storeName?: string,
    public value?: Number
  ) {
    super();
  }

  static fromJson(jsonData: any): FinancialTransactionSummary {
    return Object.assign(new FinancialTransactionSummary(), jsonData);
  }
}
