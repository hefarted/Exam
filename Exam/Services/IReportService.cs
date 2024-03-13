namespace Exam.Services
{

    public interface IReportService
    {
        Task<byte[]> GenerateReportAsync(string jsonData, string templatePath);
    }

}
