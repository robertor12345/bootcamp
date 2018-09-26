using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;

namespace BootcampSoftwareEngineeringToolsAPI.Models
{
    public static class Telemetry
    {
        public static void WriteTraceToAppInsights(string message, SeverityLevel severityLevel)
        {
            var telemetry = new TelemetryClient();
            telemetry.TrackTrace(message, severityLevel);
        }
    }
}