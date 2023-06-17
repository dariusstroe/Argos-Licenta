using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Argos.Server.Features.ProductTypeFeature
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;

        public ProductTypeController(IProductTypeService _productTypeService)
        {
            this._productTypeService = _productTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ItemType>>>> GetProductTypes()
        {
            var response = await _productTypeService.GetProductTypes();

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<ItemType>>>> AddProductType(ItemType productType)
        {
            var response = await _productTypeService.AddProductType(productType);

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<ItemType>>>> UpdateProductType(ItemType productType)
        {
            var response = await _productTypeService.UpdateProductType(productType);

            return Ok(response);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteProductType(int id)
        {
            var result = await _productTypeService.DeleteProductType(id);
            return Ok(result);
        }
    }
}
