using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Specifications;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints
{
    public class GetCount : BaseAsyncEndpoint<GetCountCatalogItemRequest, GetCountCatalogItemResponse>
    {
        private readonly IAsyncRepository<CatalogItem> _itemRepository;
        private readonly IUriComposer _uriComposer;

        public GetCount(IAsyncRepository<CatalogItem> itemRepository, IUriComposer uriComposer)
        {
            _itemRepository = itemRepository;
            _uriComposer = uriComposer;
        }

        [HttpGet("api/catalog-items/count")]
        [SwaggerOperation(
            Summary = "Get a count of the items in the Catalog",
            Description = "Gets a Count of Items in Catalog",
            OperationId = "catalog-items.Count",
            Tags = new[] { "CatalogItemEndpoints" })
        ]
        public override async Task<ActionResult<GetCountCatalogItemResponse>> HandleAsync([FromRoute] GetCountCatalogItemRequest request, CancellationToken cancellationToken)
        {
            var response = new GetCountCatalogItemResponse(request.CorrelationId());

            response.Items = await _itemRepository.CountAsync(new CatalogFilterSpecification(null, null));

            return Ok(response);
        }
    }
}
