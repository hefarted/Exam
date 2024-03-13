# ASP.NET Core WebAPI Coding Challenge

This project implements a WebAPI for a coding challenge. It provides an endpoint to generate a report based on JSON data and a template.

## Table of Contents

- [Build](#build)
- [Run](#run)
- [Sample Data](#sample-data)
- [Test](#test)
- [Design Decisions](#design-decisions)
- [Contributing](#contributing)
- [License](#license)

## Build

To build the project, follow these steps:

### Prerequisites

- .NET Core SDK (version X.X.X)
- Visual Studio (optional)

### Build Steps

1. Clone this repository.
2. Open a terminal or command prompt.
3. Navigate to the project directory.
4. Run the following command:
   ```bash
   dotnet build
   ```

## Run

To run the application, follow these steps:

### Configuration

No special configuration is required.

### Running the Application

1. Ensure that the project is built.
2. Navigate to the project directory.
3. Run the following command:
   ```bash
   dotnet run --project Exam.csproj
   ```

## Sample Data

The sample data used in this application is provided in JSON format:

```json
"[{\"firstname\":\"John\",\"lastname\":\"Doe\",\"age\":30,\"email\":\"john.doe@example.com\"},{\"firstname\":\"Jane\",\"lastname\":\"Smith\",\"age\":25,\"email\":\"jane.smith@example.com\"}]"
 ```
## Report Template Configuration

The report template is a text document that includes placeholders for dynamic data insertion. Each placeholder corresponds to a field in the JSON data. For example, <field-firstname> represents the first name field, <field-lastname> represents the last name field, and so on.

Here's an example of a report template configuration:

php
Copy code
Report Template:

```txt Name: <field-firstname> <field-lastname>
Person Details:
================
Name: <field-firstname> <field-lastname>
Age: <field-age>
Email: <field-email>

--------------------

When generating a report, the application replaces these placeholders with actual values from the JSON data to produce the final report.
```
## Test

To run tests for the project, follow these steps:

### Unit Tests

1. Navigate to the project directory.
2. Run the following command:
   ```bash
   dotnet test
   ```

## Design Decisions

### Architecture

The application follows the MVC (Model-View-Controller) architectural pattern. It consists of controllers, services, and models to handle HTTP requests, generate reports, and represent data, respectively.

### Technologies Used

- ASP.NET Core 8.0
- C#
- Newtonsoft.Json
- xUnit (for unit testing)

### Key Features

- Endpoint to generate reports based on JSON data and a template.
- Error handling for invalid input data and missing template path.
- Asynchronous processing for improved scalability.

### Limitations and Known Issues

- Currently, the application does not handle large JSON data or file uploads gracefully. This could be improved in future versions.
- Unit test for 10000000 data. (only)
- Unit test for 50mb data. (only)

## Contributing

Contributions are welcome! Feel free to submit bug reports, feature requests, or pull requests.

## License

This project is licensed under the [MIT License](LICENSE).
