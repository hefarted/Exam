namespace Exam.Services
{

    /// <summary>
    ///  The interface report service
    /// </summary>
    public interface IReportService
    {
        Task<byte[]> GenerateReportAsync(string jsonData, string templatePath);
    }

}
