using Exam.Services;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

public class ReportService : IReportService
{
    string test = "[{\"firstname\":\"John\",\"lastname\":\"Doe\",\"age\":30,\"email\":\"john.doe@example.com\"},{\"firstname\":\"Jane\",\"lastname\":\"Smith\",\"age\":25,\"email\":\"jane.smith@example.com\"}]";
    public async Task<byte[]> GenerateReportAsync(string jsonData, string templatePath)
    {
        // Read the template file
        string template = await File.ReadAllTextAsync(templatePath);

        var dataRows = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(test);

        // Generate the report
        StringBuilder reportBuilder = new StringBuilder();

        foreach (var row in dataRows)
        {
            // Apply data to the template
            string temp = template;
            foreach (var field in row)
            {
                temp = temp.Replace($"<field-{field.Key}>", field.Value);
            }

            reportBuilder.AppendLine(temp);
        }

        // Convert the report to bytes
        byte[] reportBytes = Encoding.UTF8.GetBytes(reportBuilder.ToString());

        return reportBytes;
    }
}
