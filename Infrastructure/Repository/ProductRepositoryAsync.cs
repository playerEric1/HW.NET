using ApplicationCore;
using ApplicationCore.Interfaces;
using EShopAPI.Data;

namespace Infrastructure.Repository;

public class ProductRepositoryAsync: BaseRepositoryAsync<Product>, IProductRepositoryAsync
{
    public ProductRepositoryAsync(EShopDBContext db) : base(db)
    {
    }
}