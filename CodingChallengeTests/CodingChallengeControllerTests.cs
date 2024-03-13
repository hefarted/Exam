using Exam.Controllers;
using Exam.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeTests
{
    public class CodingChallengeControllerTests
    {
        [Fact]
        public async Task GenerateReportAsync_ValidData_ReturnsFileResult()
        {
            // Arrange
            string jsonData = "[{\"firstname\":\"John\",\"lastname\":\"Doe\",\"age\":30,\"email\":\"john.doe@example.com\"}]";
            string templatePath = "path/to/template";
            byte[] reportBytes = new byte[] { 0x00, 0x01, 0x02 }; 

            var mockReportService = new Mock<IReportService>();
            mockReportService.Setup(x => x.GenerateReportAsync(It.IsAny<string>(), It.IsAny<string>()))
                             .ReturnsAsync(reportBytes);

            var controller = new CodingChallengeController(mockReportService.Object);

            // Act
            var result = await controller.GenerateReportAsync(jsonData, templatePath);

            // Assert
            var fileResult = Assert.IsType<FileContentResult>(result);
            Assert.Equal("application/octet-stream", fileResult.ContentType);
            Assert.Equal("generated_report.txt", fileResult.FileDownloadName);
            Assert.Equal(reportBytes, fileResult.FileContents);
        }


        [Fact]
        public async Task GenerateReportAsync_LargeData_ReturnsFileResult()
        {
            // Arrange
            const int largeDataCount = 1000000;
            var jsonData = GenerateLargeJsonData(largeDataCount);
            string templatePath = "path/to/template";
            byte[] reportBytes = new byte[] { 0x00, 0x01, 0x02 }; // Example report bytes

            var mockReportService = new Mock<IReportService>();
            mockReportService.Setup(x => x.GenerateReportAsync(It.IsAny<string>(), It.IsAny<string>()))
                             .ReturnsAsync(reportBytes);

            var controller = new CodingChallengeController(mockReportService.Object);

            // Act
            var result = await controller.GenerateReportAsync(jsonData, templatePath);

            // Assert
            var fileResult = Assert.IsType<FileContentResult>(result);
            Assert.Equal("application/octet-stream", fileResult.ContentType);
            Assert.Equal("generated_report.txt", fileResult.FileDownloadName);
            Assert.Equal(reportBytes, fileResult.FileContents);
        }
        
        [Fact]
        public async Task GenerateReportAsync_LargeJsonFile_ReturnsFileResult()
        {
            // Arrange
            const long fileSize = 50 * 1024 * 1024; // 50 MB
            var jsonData = GenerateLargeJsonDataFile(fileSize);
            string templatePath = "path/to/template";
            byte[] reportBytes = new byte[] { 0x00, 0x01, 0x02 }; // Example report bytes

            var mockReportService = new Mock<IReportService>();
            mockReportService.Setup(x => x.GenerateReportAsync(It.IsAny<string>(), It.IsAny<string>()))
                             .ReturnsAsync(reportBytes);

            var controller = new CodingChallengeController(mockReportService.Object);

            // Act
            var result = await controller.GenerateReportAsync(jsonData, templatePath);

            // Assert
            var fileResult = Assert.IsType<FileContentResult>(result);
            Assert.Equal("application/octet-stream", fileResult.ContentType);
            Assert.Equal("generated_report.txt", fileResult.FileDownloadName);
            Assert.Equal(reportBytes, fileResult.FileContents);
        }

        private string GenerateLargeJsonDataFile(long sizeInBytes)
        {
            // Generate a JSON string with the specified size
            var largeData = new StringBuilder();
            while (largeData.Length < sizeInBytes)
            {
                largeData.Append("{\"firstname\":\"John\",\"lastname\":\"Doe\",\"age\":30,\"email\":\"john.doe@example.com\"},");
            }
            largeData.Remove(largeData.Length - 1, 1); // Remove the last comma
            return $"[{largeData}]";
        }

        private string GenerateLargeJsonData(int count)
        {
            var jsonArray = new JArray();

            for (int i = 0; i < count; i++)
            {
                jsonArray.Add(new JObject(
                    new JProperty("firstname", $"First{i}"),
                    new JProperty("lastname", $"Last{i}"),
                    new JProperty("age", i % 100),
                    new JProperty("email", $"person{i}@example.com")
                ));
            }

            return jsonArray.ToString();
        }

       
    }
}
