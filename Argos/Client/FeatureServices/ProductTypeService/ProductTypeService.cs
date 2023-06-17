using Argos.Shared;

namespace Argos.Client.Services.ProductTypeService
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly HttpClient _http;

        public ProductTypeService(HttpClient http)
        {
            _http = http;
        }
        public List<ItemType> ProductTypes { get; set; } = new List<ItemType>();

        public event Action OnChange;

		public async Task AddProductType(ItemType productType)
		{
            var response = await _http.PostAsJsonAsync("api/producttype", productType);
            ProductTypes = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<ItemType>>>()).Data;

            OnChange.Invoke();
		}

		public ItemType CreateNewProductType()
		{
            var newProductType =  new ItemType
            {
                IsNew = true,
                Editing = true,
            };

            ProductTypes.Add(newProductType);
            OnChange.Invoke();

            return newProductType;
		}

        public async Task DeleteProductType(int productTypeId)
        {
            var result = await _http.DeleteAsync($"api/producttype/{productTypeId}");
            await GetProductTypes();
			OnChange?.Invoke();
		}

		public async Task GetProductTypes()
        {
            var result = await _http
                            .GetFromJsonAsync<ServiceResponse<List<ItemType>>>("api/producttype");
            ProductTypes = result.Data;
        }

		public async Task UpdateProductType(ItemType productType)
		{
			var response = await _http.PutAsJsonAsync("api/producttype", productType);
			ProductTypes = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<ItemType>>>()).Data;

			OnChange.Invoke();
		}
	}
}
