Great! Since you have an example CSV file directly in your repository, you can include that in your `README.md` to help users understand how to use the application with a concrete example.

Here’s how you can update the `README.md` to reference the example file:

---

# Log Query Console Application

## Introduction

This console application parses a log CSV file and prints out logs based on a custom query. It allows users to search for logs across various columns using flexible query syntax. The application also supports basic severity-based alerting.

## Getting Started

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) (version 3.1 or later)

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/yourrepository.git
   cd yourrepository
   ```

2. Build the solution:
   ```bash
   dotnet build
   ```

3. Run the application:
   ```bash
   dotnet run
   ```

### Example CSV File

The repository includes an example CSV file named `20220601182758.csv`. This file contains sample logs that you can use to test the application.

### CSV File Format

The application expects a CSV file with the following headers:

```plaintext
deviceVendor,deviceProduct,deviceVersion,signatureId,severity,name,start,rt,msg,shost,smac,dhost,dmac,suser,suid,externalId,cs1Label,cs1
```

### Usage

1. **Running the Application**

   Upon running the application, you will be prompted to enter the path to your CSV log file. You can use the included example file:
   
   ```plaintext
   Enter the path to the CSV log file: 20220601182758.csv
   ```

   After entering the file path, the application will load the logs.

2. **Severity-Based Alerting**

   The application will then ask for a severity level to trigger alerts. You can enter a severity level as an integer:
   
   ```plaintext
   Enter the severity level for alerts:
   ```

   If you enter a valid severity level (e.g., `3`), the application will check the logs and alert you if any logs meet or exceed this severity level.

3. **Querying the Logs**

   After entering the severity level, you can query the logs using custom queries. The application supports basic and advanced queries using the following syntax:

   - **Exact Match**: Search for logs with an exact value in a column.
     ```plaintext
     column_name='value'
     ```

   - **Partial Match**: Search for logs where the column contains a value.
     ```plaintext
     column_name='*value*'
     ```

   - **Combining Queries with `AND`**: Search for logs where multiple conditions are met.
     ```plaintext
     column1='value1' AND column2='value2'
     ```

   - **Combining Queries with `OR`**: Search for logs where at least one condition is met.
     ```plaintext
     column1='value1' OR column2='value2'
     ```

4. **Example Queries**

   - **Find all logs with severity level 3**:
     ```plaintext
     severity='3'
     ```

   - **Find all logs where the device vendor is `Microsoft` and severity is 3**:
     ```plaintext
     deviceVendor='Microsoft' AND severity='3'
     ```

   - **Find logs where the signatureId contains `4624`**:
     ```plaintext
     signatureId='*4624*'
     ```

   - **Find logs where the user is `JImca` or `RIesa`**:
     ```plaintext
     suser='JImca' OR suser='RIesa'
     ```

5. **Output**

   The results of your query will be printed in JSON format. Each log entry will include all fields, and the output will also include the count of logs returned.

   **Example Output**:
   ```json
   {
       "SearchQuery": "deviceVendor='Microsoft' AND severity='3'",
       "Result": [
           {
               "DeviceVendor": "Microsoft",
               "DeviceProduct": "Windows Vista",
               "DeviceVersion": 1.0,
               "SignatureId": "Microsoft-Windows-Security-Auditing:4624",
               "Severity": 3,
               "Name": "An account was successfully logged on.",
               "Start": "2022-05-29T15:46:44.960000Z",
               "Rt": 1653839204.96,
               "Msg": "This event is generated when a logon session is created...",
               "Shost": "LAPTOP-O4EY5H79RR",
               "Smac": "00:E0:4C:c7:fb:98",
               "Dhost": "w2016r2004-srv",
               "Dmac": "78:0C:B8:90:6b:46",
               "Suser": "LAPTOP-O4EY5H79RR$",
               "Suid": "0x349980f",
               "ExternalId": 4624,
               "Cs1Label": "payload",
               "Cs1": "",
               "Sproc": ""
           }
       ],
       "Count": 1
   }
   ```

### License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

### Acknowledgements

- [CsvHelper](https://joshclose.github.io/CsvHelper/) - Used for reading and parsing CSV files.
- [Newtonsoft.Json](https://www.newtonsoft.com/json) - Used for JSON serialization.

---

This `README.md` now includes a reference to the example CSV file in your repository, making it easier for users to understand how to use the application and test it immediately after cloning the repository.

Faktas kad šitą rašiau su ChatGPT xD
