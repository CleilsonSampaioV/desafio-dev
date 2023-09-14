export class CommandResult {
  constructor(
    public IsSuccess?: boolean,
    public Errors?: any,
  ) {}

  static fromJson(jsonData: any): CommandResult {
    return Object.assign(new CommandResult(), jsonData);
  }
}
