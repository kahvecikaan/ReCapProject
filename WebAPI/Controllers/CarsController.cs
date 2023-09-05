using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly ICarService _carService;

    public CarsController(ICarService carService)
    {
        _carService = carService;
    }
    
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _carService.GetAll();
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    [HttpGet("getbycarid")]
    public IActionResult GetByCarId(int id)
    {
        var result = _carService.GetByCarId(id);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    [HttpGet("getbybrandid")]
    public IActionResult GetByBrandId(int id)
    {
        var result = _carService.GetCarsByBrandId(id);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    [HttpGet("getbycolorid")]
    public IActionResult GetByColorId(int id)
    {
        var result = _carService.GetCarsByColorId(id);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    [HttpGet("getcardetails")]
    public IActionResult GetCarDetails()
    {
        var result = _carService.GetCarDetails();
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    [HttpPost("addcar")]
    public IActionResult Add(Car car)
    {
        var result = _carService.Add(car);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    [HttpPost("updatecar")]
    public IActionResult Update(Car car)
    {
        var result = _carService.Update(car);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    [HttpPost("deletecar")]
    public IActionResult Delete(Car car)
    {
        var result = _carService.Delete(car);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}