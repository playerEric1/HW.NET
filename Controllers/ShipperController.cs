using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShipperController : ControllerBase
{
    // GET: api/<ShipperController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new[] { "value1", "value2" };
    }

    // GET api/<ShipperController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<ShipperController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<ShipperController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ShipperController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}