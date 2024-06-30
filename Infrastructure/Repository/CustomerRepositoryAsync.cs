using ApplicationCore;
using ApplicationCore.Interfaces;
using EShopAPI.Data;

namespace Infrastructure.Repository;

public class CustomerRepositoryAsync : BaseRepositoryAsync<Customer>, ICustomerRepositoryAsync
{
    public CustomerRepositoryAsync(EShopDBContext db) : base(db)
    {
    }
}

