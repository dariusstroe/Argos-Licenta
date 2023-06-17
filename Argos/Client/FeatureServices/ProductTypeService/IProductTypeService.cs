namespace Argos.Client.Services.ProductTypeService
{
    public interface IProductTypeService
    {
        event Action OnChange;
        public List<ItemType> ProductTypes { get; set; }
        Task GetProductTypes();
        Task AddProductType(ItemType productType);
        Task UpdateProductType(ItemType productType);
        ItemType CreateNewProductType();
        Task DeleteProductType(int productTypeId);
    }
}
