using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete;

public class CarImageManager : ICarImageService
{
    private readonly ICarImageDal _carImageDal;

    public CarImageManager(ICarImageDal carImageDal)
    {
        _carImageDal = carImageDal;
    }

    public IResult Add(IFormFile file, CarImage carImage)
    {
        Console.WriteLine($"Before setting properties: Date = {carImage.Date}, ImagePath = {carImage.ImagePath}");
        
        var result = BusinessRules.
            Run(CheckIfCarImageLimitExceeded(carImage.CarId), CheckIfImageExtensionValid(file));
        if (result != null)
        {
            return result;
        }
        
        carImage.ImagePath = FileHelper.Upload(file).Data;
        carImage.Date = DateTime.Now.ToString("O");
        
        Console.WriteLine($"After setting properties: Date = {carImage.Date}, ImagePath = {carImage.ImagePath}");

        try
        {
            Console.WriteLine($"Adding to database: Date = {carImage.Date}, ImagePath = {carImage.ImagePath}");
            _carImageDal.Add(carImage);
            Console.WriteLine("Added to database successfully.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"An exception occurred: {e.Message}");
            return new ErrorResult("An error occurred while adding the record to the database.");
        }
        
        return new SuccessResult(Messages.CarImageAdded);
    }

    public IResult Delete(CarImage carImage)
    {
        var carImageToDelete = _carImageDal.Get(c => c.CarImageId == carImage.CarImageId);
        if (carImageToDelete == null)
        {
            return new ErrorResult(Messages.CarImageNotFound);
        }

        var result = FileHelper.Delete(carImageToDelete.ImagePath);
        if (!result.Success)
        {
            return result;
        }
        
        _carImageDal.Delete(carImageToDelete);
        return new SuccessResult(Messages.CarImageDeleted);
    }

    public IResult Update(IFormFile file, CarImage carImage)
    {
        var oldCarImage = _carImageDal.GetAll(c => c.CarImageId == carImage.CarImageId).FirstOrDefault();
        if (oldCarImage == null)
        {
            return new ErrorResult(Messages.CarImageNotFound);
        }
        
        var result = FileHelper.Update(file, oldCarImage.ImagePath);
        if (!result.Success)
        {
            return result;
        }
        
        carImage.ImagePath = result.Data;
        carImage.Date = DateTime.Now.ToString("O");
        _carImageDal.Update(carImage);
        return new SuccessResult(Messages.CarImageUpdated);
    }

    public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
    {
        var result = _carImageDal.GetAll(c => c.CarId == carId);
        if (result.Count == 0)
        {
            return new SuccessDataResult<List<CarImage>>(new List<CarImage>
            {
                new()
                {
                    CarId = carId,
                    ImagePath = FileHelper.DefaultImagePath,
                    Date = DateTime.Now.ToString("O")
                }
            });
        }
        
        return new SuccessDataResult<List<CarImage>>(result);
    }
    
    private IResult CheckIfCarImageLimitExceeded(int carId)
    {
        var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
        if (result >= 5)
        {
            return new ErrorResult(Messages.ImageLimitExceeded);
        }

        return new SuccessResult();
    }
    
    private IResult CheckIfImageExtensionValid(IFormFile file)
    {
        var isValidExtension = Messages.ValidImageFileTypes.
            Any(t => t == Path.GetExtension(file.FileName).ToUpper());
        if (!isValidExtension)
        {
            return new ErrorResult(Messages.InvalidImageExtension);
        }

        return new SuccessResult();
    }
}