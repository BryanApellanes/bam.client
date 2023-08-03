namespace Bam.Client
{
    public interface IApiErrorResponse
    {
        ErrorCause[] ErrorCauses { get; set; }
        string ErrorCode { get; set; }
        string ErrorId { get; set; }
        string ErrorLink { get; set; }
        string ErrorSummary { get; set; }
    }
}