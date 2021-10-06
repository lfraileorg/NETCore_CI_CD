using System;

namespace Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints
{
    public class GetCountCatalogItemResponse : BaseResponse
    {
        public GetCountCatalogItemResponse(Guid correlationId) : base(correlationId)
        {
        }

        public GetCountCatalogItemResponse()
        {
        }

        public int Items { get; set; }
    }
}
