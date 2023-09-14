namespace FinancialStore.Contracts.DTO;

public record BaseCommandResult
{
    public bool IsSuccess { get; set; }
    public string[] Errors { get; set; }
}