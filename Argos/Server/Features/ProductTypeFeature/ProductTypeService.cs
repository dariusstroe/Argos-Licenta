using Argos.Client.Pages.Admin;

namespace Argos.Server.Features.ProductTypeFeature
{
	public class ProductTypeService : IProductTypeService
	{
		private readonly DataContext _context;

		public ProductTypeService(DataContext context)
		{
			_context = context;
		}

		public async Task<ServiceResponse<List<ItemType>>> AddProductType(ItemType productType)
		{
			productType.Editing = productType.IsNew = false;
			_context.ItemTypes.Add(productType);
			await _context.SaveChangesAsync();

			return await GetProductTypes();
		}

		public async Task<ServiceResponse<bool>> DeleteProductType(int productTypeId)
		{
			var dbProductType = await _context.ItemTypes.FindAsync(productTypeId);

			if (dbProductType == null)
			{
				return new ServiceResponse<bool>
				{
					Success = false,
					Message = "Product Type not found"
				};
			}

			_context.ItemTypes.Remove(dbProductType);
			await _context.SaveChangesAsync();

			return new ServiceResponse<bool> { Data = true };
		}

		public async Task<ServiceResponse<List<ItemType>>> GetProductTypes()
		{
			var productTypes = await _context.ItemTypes.ToListAsync();

			return new ServiceResponse<List<ItemType>>
			{
				Data = productTypes,
			};
		}

		public async Task<ServiceResponse<List<ItemType>>> UpdateProductType(ItemType productType)
		{
			var dbProductType = await _context.ItemTypes.FindAsync(productType.Id);

			if (dbProductType == null)
			{
				return new ServiceResponse<List<ItemType>>
				{
					Success = false,
					Message = "Product Type not found"
				};
			}

			dbProductType.Name = productType.Name;
			await _context.SaveChangesAsync();

			return await GetProductTypes();
		}
	}
}
