using Microsoft.eShopWeb.ApplicationCore.Entities;
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

        public static TelemetryEvent CreateOrderEvent(Entities.OrderAggregate.OrderItem orderItem)
        {
            var myEvent = new TelemetryEvent(TelemetryEventType.AddOrderEvent);
            myEvent.AddProperty("productId", orderItem.ItemOrdered.CatalogItemId.ToString());
            myEvent.AddProperty("product", orderItem.ItemOrdered.ProductName);
            myEvent.AddProperty("price", $"{orderItem.UnitPrice * orderItem.Units}");

            return myEvent;
        }

        public void AddProperty(string name, string value)
        {
            _properties.Add(name, value);
        }
    }

    public class TelemetryEventType
    {
        public static TelemetryEventType AddOrderEvent = new TelemetryEventType(nameof(AddOrderEvent));

        public string TypeName { get; private set; }

        private TelemetryEventType(string typeName)
        {
            TypeName = typeName;
        }
    }
}
