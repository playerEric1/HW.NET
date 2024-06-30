using ApplicationCore;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;

namespace Infrastructure.Services;

public class CustomerServiceAsync : ICustomerServiceAsync
{
    private readonly ICustomerRepositoryAsync customerRepository;
    public CustomerServiceAsync(ICustomerRepositoryAsync repo)
    {
        customerRepository = repo;
    }

    public async Task<int> UpdateCusomerAsync(CustomerRequestModel _model, int id)
    {
        Customer model = new Customer();
        model.FirstName = _model.FirstName;
        model.LastName = _model.LastName;
        model.City = _model.City;
        model.Gender = _model.Gender;
        model.Phone = _model.Phone;
        model.Id = id;
        return await customerRepository.UpdateAsync(model);
    }

    public async Task<int> InsertCustomerAsync(CustomerRequestModel customer)
    {
        Customer c = new Customer();
        c.City = customer.City;
        c.Gender = customer.Gender;
        c.Phone = customer.Phone;
        c.FirstName = customer.FirstName;
        c.LastName = c.LastName;
        return await customerRepository.InsertAsync(c);
    }

    public async Task<IEnumerable<CustomerResponseModel>> GetAllCustomerAsync()
    {
        var result = await customerRepository.GetAllAsync();
        List<CustomerResponseModel> responseModels = new List<CustomerResponseModel>();
        foreach (var item in result)
        {
            CustomerResponseModel model = new CustomerResponseModel();
            model.FirstName = item.FirstName;
            model.LastName = item.LastName;
            model.City = item.City;
            model.Gender = item.Gender;
            model.Phone = item.Phone;
            responseModels.Add(model);
        }

        return responseModels;
    }

    public async Task<int> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteCustomerAsync(int id)
    {
        return await customerRepository.DeleteAsync(id);
    }

    public async Task<CustomerResponseModel> GetCustomerByIdAsync(int id)
    {
        var item = await customerRepository.GetAsync(id);
        CustomerResponseModel model = new CustomerResponseModel();
        model.FirstName = item.FirstName;
        model.LastName = item.LastName;
        model.City = item.City;
        model.Gender = item.Gender;
        model.Phone = item.Phone;
        return model;
    }
}