using Exam.Controllers;
using Exam.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ExamUnitTest
{
    public class CodingChallengeControllerTests
    {
        [Fact]
        public async Task GenerateReportAsync_ValidData_ReturnsFileResult()
        {
            // Arrange
            string jsonData = "[{\"firstname\":\"John\",\"lastname\":\"Doe\",\"age\":30,\"email\":\"john.doe@example.com\"}]";
            string templatePath = "path/to/template";
            byte[] reportBytes = new byte[] { 0x00, 0x01, 0x02 }; // Example report bytes

            var mockReportService = new Mock<IReportService>();
            mockReportService.Setup(x => x.GenerateReportAsync(It.IsAny<string>(), It.IsAny<string>()))
                             .ReturnsAsync(reportBytes);

            //var controller = new CodingChallengeController(mockReportService.Object);

            //// Act
            //var result = await controller.GenerateReportAsync(jsonData, templatePath);

            //// Assert
            //var fileResult = Assert.IsType<FileContentResult>(result);
            //Assert.Equal("application/octet-stream", fileResult.ContentType);
            //Assert.Equal("generated_report.txt", fileResult.FileDownloadName);
            //Assert.Equal(reportBytes, fileResult.FileContents);
        }

    }
}
