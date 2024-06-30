using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShoppingCart : ControllerBase
{
    // GET: api/<ShoppingCart>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new[] { "value1", "value2" };
    }

    // GET api/<ShoppingCart>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<ShoppingCart>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<ShoppingCart>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ShoppingCart>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}