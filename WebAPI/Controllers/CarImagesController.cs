using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarImagesController : ControllerBase
{
    private readonly ICarImageService _carImageService;

    public CarImagesController(ICarImageService carImageService)
    {
        _carImageService = carImageService;
    }
    
    [HttpPost("add")]
    public IActionResult Add([FromForm] IFormFile file, [FromForm] CarImage carImage)
    {
        var result = _carImageService.Add(file, carImage);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    [HttpPost("update")]
    public IActionResult Update([FromForm] IFormFile file, [FromForm] CarImage carImage)
    {
        var result = _carImageService.Update(file, carImage);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    [HttpPost("delete")]
    public IActionResult Delete(CarImage carImage)
    {
        var result = _carImageService.Delete(carImage);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    [HttpGet("getbycarid")]
    public IActionResult GetByCarId(int carId)
    {
        var result = _carImageService.GetImagesByCarId(carId);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}
