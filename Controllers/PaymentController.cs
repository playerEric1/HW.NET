using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    // GET: api/<PaymentController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new[] { "value1", "value2" };
    }

    // GET api/<PaymentController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<PaymentController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<PaymentController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<PaymentController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}