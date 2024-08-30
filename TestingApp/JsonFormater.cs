using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApp
{
    public static class JsonFormater
    {
        public static string FormatAsJson(string query, List<LogEntry> results)
        {
            var output = new
            {
                SearchQuery = query,
                Result = results,
                Count = results.Count
            };
            return JsonConvert.SerializeObject(output, Formatting.Indented);
        }

        public static List<LogEntry> ReadCsv(string filePath)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                BadDataFound = null, // Ignore bad data
                MissingFieldFound = null, // Ignore missing fields
                HeaderValidated = null, // Ignore header validation errors
                HasHeaderRecord = true,
                Delimiter = ",",
            };

            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, config);
            csv.Context.RegisterClassMap<LogEntryMap>(); // Register the class map
            return csv.GetRecords<LogEntry>().ToList();
        }

        public static List<LogEntry> ReadCsvFiles(IEnumerable<string> filePaths)
        {
            var logs = new List<LogEntry>();

            foreach (var filePath in filePaths)
            {
                logs.AddRange(ReadCsv(filePath));
            }

            return logs;
        }

    }
    

}
