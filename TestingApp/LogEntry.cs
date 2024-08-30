using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApp
{
    public class LogEntry
    {
        public string DeviceVendor { get; set; }
        public string DeviceProduct { get; set; }
        public string DeviceVersion { get; set; }
        public string SignatureId { get; set; }
        public int Severity { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public double Rt { get; set; }
        public string Msg { get; set; }
        public string Shost { get; set; }
        public string Smac { get; set; }
        public string Dhost { get; set; }
        public string Dmac { get; set; }
        public string Suser { get; set; }
        public string Suid { get; set; }
        public int ExternalId { get; set; }
        public string Cs1Label { get; set; }
        public string Cs1 { get; set; }
        // public string Sproc { get; set; } // Remove or comment out this line
    }

}
