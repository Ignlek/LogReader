using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace TestingApp
{


    public class LogEntryMap : ClassMap<LogEntry>
    {
        public LogEntryMap()
        {
            Map(m => m.DeviceVendor).Name("deviceVendor");
            Map(m => m.DeviceProduct).Name("deviceProduct");
            Map(m => m.DeviceVersion).Name("deviceVersion");
            Map(m => m.SignatureId).Name("signatureId");
            Map(m => m.Severity).Name("severity");
            Map(m => m.Name).Name("name");
            Map(m => m.Start).Name("start");
            Map(m => m.Rt).Name("rt");
            Map(m => m.Msg).Name("msg");
            Map(m => m.Shost).Name("shost");
            Map(m => m.Smac).Name("smac");
            Map(m => m.Dhost).Name("dhost");
            Map(m => m.Dmac).Name("dmac");
            Map(m => m.Suser).Name("suser");
            Map(m => m.Suid).Name("suid");
            Map(m => m.ExternalId).Name("externalId");
            Map(m => m.Cs1Label).Name("cs1Label");
            Map(m => m.Cs1).Name("cs1");
            // Map the sproc property, but make it optional
            //Map(m => m.Sproc).Name("sproc").Optional();
        }
    }

}
