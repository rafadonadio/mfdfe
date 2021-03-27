using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace MFD.Clases
{
    public class Logger
    {
        static Logger()
        {
            if (!EventLog.SourceExists("MFD"))
            {
                EventLog.CreateEventSource("MFD-FE", "MFD");
            }
        }

        public static void EscribirEventLog(string msg)
        {
            EventLog log = new EventLog("MFD", System.Environment.MachineName, "MFD-FE");
            log.WriteEntry(msg, EventLogEntryType.Error);
        }
        public static void EscribirEventLog(Exception ex)
        {
            EscribirEventLog(ex.Message);
        }

    }
}
