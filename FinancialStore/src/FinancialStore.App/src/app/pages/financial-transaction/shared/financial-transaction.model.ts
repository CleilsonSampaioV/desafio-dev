import { BaseResourceModel } from '../../../shared/models/base-resource.model';

export class FinancialTransaction extends BaseResourceModel {
  constructor(
    public Type?: Number,
    public Date?: string,
    public Value?: string,
    public Cpf?: string,
    public CardNumber?: string,
    public Hour?: string,
    public StoreOwner?: string,
    public StoreName?: string,
  ) {
    super();
  }


  static fromJson(jsonData: any): FinancialTransaction {
    return Object.assign(new FinancialTransaction(), jsonData);
  }
}
