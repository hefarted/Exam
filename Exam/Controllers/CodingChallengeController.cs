using Exam.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;


namespace Exam.Controllers
{
    /// <summary>
    ///  The coding challenge controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CodingChallengeController : ControllerBase
    {
        private readonly IReportService _reportService;

        /// <summary>
        ///  The coding challenge controller constructor.
        /// </summary>
        /// <param name="reportService"></param>
        public CodingChallengeController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> GenerateReportAsync([FromBody] string jsonData, [FromQuery] string templatePath)
        {
            if (string.IsNullOrEmpty(jsonData))
                return BadRequest("JSON data is required.");

            if (string.IsNullOrEmpty(templatePath))
                return BadRequest("Template path is required.");

            // Deserialize the JSON string to a JArray

            try
            {
                JArray jsonArray = JArray.Parse(jsonData);

                // Convert the JArray back to a string
                string jsonString = jsonArray.ToString();

                // Call the service to generate the report
                byte[] reportBytes = await _reportService.GenerateReportAsync(jsonString, templatePath);

                // Return the report as a file attachment
                return File(reportBytes, "application/octet-stream", "generated_report.txt");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while generating the report.");
            }
        }
    }
}
