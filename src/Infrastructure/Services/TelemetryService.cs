using Microsoft.ApplicationInsights;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System;

namespace Microsoft.eShopWeb.Infrastructure.Services
{
    public class TelemetryService : ITelemetryService
    {
        private readonly TelemetryClient _telemetryClient;

        public TelemetryService(TelemetryClient telemetryClient)
        {
            _telemetryClient = telemetryClient ?? throw new ArgumentNullException(nameof(telemetryClient));
        }

        public void TraceEvent(TelemetryEvent eventTelemetry)
        {
            _telemetryClient.TrackEvent(eventTelemetry.Name, eventTelemetry.Properties);            
        }

    }
}
