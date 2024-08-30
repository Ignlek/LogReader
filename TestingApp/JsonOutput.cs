using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApp
{
    public static class JsonOutput
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
    }
}
