using System.Runtime.InteropServices.JavaScript;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerServiceAsync _customerServiceAsync;

    public CustomerController(ICustomerServiceAsync customerServiceAsync)
    {
        _customerServiceAsync = customerServiceAsync;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CustomerRequestModel customerRequestModel)
    {
        var result = await _customerServiceAsync.InsertCustomerAsync(customerRequestModel);
        if (result > 0) return Ok();
        return BadRequest(result);
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _customerServiceAsync.GetAllCustomerAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _customerServiceAsync.GetCustomerByIdAsync(id));
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _customerServiceAsync.DeleteCustomerAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Put(CustomerRequestModel model, [FromQuery] int id)
    {
        return Ok(await _customerServiceAsync.UpdateCusomerAsync(model, id));
    }
}