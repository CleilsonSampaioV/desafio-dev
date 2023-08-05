namespace FinancialStore.Contracts.DTO;

public class BaseResponseDTO
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public string[] Errors { get; set; }
}