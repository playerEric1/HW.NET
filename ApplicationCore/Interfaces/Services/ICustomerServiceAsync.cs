using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;

namespace ApplicationCore.Interfaces.Services;

public interface ICustomerServiceAsync
{
    public Task<int> UpdateCusomerAsync(CustomerRequestModel model, int id);
    public Task<int> InsertCustomerAsync(CustomerRequestModel customer);
    public Task<IEnumerable<CustomerResponseModel>> GetAllCustomerAsync();
    public Task<int> DeleteCustomerAsync(int id);
    public Task<CustomerResponseModel> GetCustomerByIdAsync(int id);
}