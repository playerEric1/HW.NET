using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Services;

namespace Infrastructure.Services;

public class ProductServiceAsync: IProductServiceAsync
{
    private readonly IProductRepositoryAsync _repo;

    public ProductServiceAsync(IProductRepositoryAsync repo)
    {
        _repo = repo;
    }
}