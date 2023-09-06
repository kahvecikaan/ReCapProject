using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _customerService.GetAll();
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
        var result = _customerService.GetById(id);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    [HttpGet("getbyuserid")]
    public IActionResult GetByUserId(int userId)
    {
        var result = _customerService.GetByUserId(userId);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    [HttpGet("getallcustomerdetails")]
    public IActionResult GetAllCustomerDetails()
    {
        var result = _customerService.GetAllCustomerDetails();
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    [HttpPost("add")]
    public IActionResult Add(Customer customer)
    {
        var result = _customerService.Add(customer);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    [HttpPost("update")]
    public IActionResult Update(Customer customer)
    {
        var result = _customerService.Update(customer);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    [HttpPost("delete")]
    public IActionResult Delete(Customer customer)
    {
        var result = _customerService.Delete(customer);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}