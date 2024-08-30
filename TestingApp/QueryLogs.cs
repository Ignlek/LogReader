using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestingApp
{
    public static class QueryLogs
    {
        public static List<LogEntry> GetQueryLogs(List<LogEntry> logs, string query)
        {
            var queryParts = query.Split(new[] { "AND", "OR" }, StringSplitOptions.RemoveEmptyEntries);
            bool isAndQuery = query.Contains("AND");

            Func<LogEntry, bool> predicate = log =>
            {
                foreach (var part in queryParts)
                {
                    var keyValue = part.Split('=');
                    if (keyValue.Length != 2)
                    {
                        throw new ArgumentException("Invalid query format.");
                    }

                    var column = keyValue[0].Trim();
                    var searchValue = keyValue[1].Trim().Trim('\'');

                    var prop = typeof(LogEntry).GetProperty(column, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                    if (prop == null) throw new ArgumentException("Column not found.");

                    var propValue = prop.GetValue(log)?.ToString();
                    bool matches = propValue != null && (propValue.Equals(searchValue, StringComparison.OrdinalIgnoreCase) ||
                                                         propValue.Contains(searchValue, StringComparison.OrdinalIgnoreCase));

                    if (isAndQuery && !matches) return false;
                    if (!isAndQuery && matches) return true;
                }

                return isAndQuery;
            };

            return logs.Where(predicate).ToList();
        }
    }
}
