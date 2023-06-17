namespace Argos.Server.Features.ProductTypeFeature;

    public interface IProductTypeService
    {
        Task<ServiceResponse<List<ItemType>>> GetProductTypes();
	Task<ServiceResponse<List<ItemType>>> AddProductType(ItemType productType);
	Task<ServiceResponse<List<ItemType>>> UpdateProductType(ItemType productType);
	Task<ServiceResponse<bool>> DeleteProductType(int productTypeId);


}
