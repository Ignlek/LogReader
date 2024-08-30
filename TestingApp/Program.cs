using TestingApp;
class Program
{
    static void Main(string[] args)
    {
        var filePath = "../../../20220601182758.csv"; // Use the provided file path

        // Read logs from the file
        var logs = JsonFormater.ReadCsv(filePath);

        Console.WriteLine("Enter the severity level for alerts:");
        if (int.TryParse(Console.ReadLine(), out int alertSeverity))
        {
            CheckSeverityAlerts(logs, alertSeverity);
        }
        else
        {
            Console.WriteLine("Invalid severity level. No alerts will be generated.");
        }

        while (true)
        {
            Console.WriteLine("Enter your query:");
            var query = Console.ReadLine();

            try
            {
                var results = QueryLogs.GetQueryLogs(logs, query);
                var jsonResult = JsonFormater.FormatAsJson(query, results);
                Console.WriteLine(jsonResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
    public static void CheckSeverityAlerts(List<LogEntry> logs, int alertSeverity)
    {
        var severeLogs = logs.Where(log => log.Severity >= alertSeverity).ToList();
        if (severeLogs.Any())
        {
            Console.WriteLine($"Alert: {severeLogs.Count} logs found with severity {alertSeverity} or higher.");
            foreach (var log in severeLogs)
            {
                Console.WriteLine($"Severity: {log.Severity}, Message: {log.Name}, Time: {log.Start}");
            }
        }
        else
        {
            Console.WriteLine($"No logs found with severity {alertSeverity} or higher.");
        }
    }
}
