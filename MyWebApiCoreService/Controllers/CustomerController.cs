using Microsoft.AspNetCore.Mvc;
using MvcDHProject.Models;
using MyWebApiCoreService.Models;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerDal _dal;
    public CustomerController(ICustomerDal dal)
    {
        _dal = dal;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CUSTOMER>> Get()
    {
        return _dal.Customers_Select().OrderBy(c=>c.CustId).ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<CUSTOMER> Get(int id)
    {
        var customer = _dal.Customer_Select(id);
        if (customer == null)
            return NotFound();
        return customer;
    }

    [HttpPost]
    public IActionResult Post([FromForm] CUSTOMER customer)
    {
        _dal.Customer_Insert(customer);
        return Ok();
    }

    [HttpPut]
    public IActionResult Put([FromForm] CUSTOMER customer)
    {
        _dal.Customer_Update(customer);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _dal.Customer_Delete(id);
        return Ok();
    }
}
