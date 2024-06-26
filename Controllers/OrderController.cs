using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    // GET: api/<OrderController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new[] { "value1", "value2" };
    }

    // GET api/<OrderController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<OrderController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<OrderController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<OrderController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}