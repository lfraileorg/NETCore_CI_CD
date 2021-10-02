using System.Collections.Generic;

namespace Microsoft.eShopWeb.ApplicationCore.Interfaces
{
    public interface ITelemetryService
    {
        public void TraceEvent(TelemetryEvent eventTelemetry);
    }


    public class TelemetryEvent
    {
        private Dictionary<string, string> _properties = new Dictionary<string, string>();

        public string Name { get; private set; }
        public Dictionary<string, string> Properties => _properties;

        private TelemetryEvent(TelemetryEventType eventType)
        {
            Name = eventType.TypeName;
            _properties.Add("type", eventType.TypeName);
        }

        public static TelemetryEvent CreateAddBasketEvent(int product, decimal price)
        {
            var myEvent = new TelemetryEvent(TelemetryEventType.AddBasketEvent);
            myEvent.AddProperty(nameof(product), product.ToString());
            myEvent.AddProperty(nameof(price), price.ToString());

            return myEvent;
        }

        public void AddProperty(string name, string value)
        {
            _properties.Add(name, value);
        }
    }

    public class TelemetryEventType
    {
        public static TelemetryEventType AddBasketEvent = new TelemetryEventType(nameof(AddBasketEvent));

        public string TypeName { get; private set; }

        private TelemetryEventType(string typeName)
        {
            TypeName = typeName;
        }
    }
}
