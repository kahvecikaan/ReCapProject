using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete;

public class CarManager : ICarService
{
    private readonly ICarDal _carDal;

    public CarManager(ICarDal carDal)
    {
        _carDal = carDal;
    }

    public IDataResult<List<Car>> GetAll()
    {
        // business logic...
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
    }
    
    [ValidationAspect(typeof(CarValidator))]
    public IResult Add(Car car)
    {
        // business logic...
        _carDal.Add(car);
        return new SuccessResult(Messages.CarAdded);
    }

    public IResult Update(Car car)
    {
        // business logic...
        _carDal.Update(car);
        return new SuccessResult(Messages.CarUpdated);
    }

    public IResult Delete(Car car)
    {
        // business logic...
        _carDal.Delete(car);
        return new SuccessResult(Messages.CarDeleted);
    }
    
    public IDataResult<Car> GetByCarId(int id)
    {
        return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id));
    }

    public IDataResult<List<Car>> GetCarsByBrandId(int id)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
    }

    public IDataResult<List<Car>> GetCarsByColorId(int id)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
    }

    public IDataResult<List<CarDetailDto>> GetCarDetails()
    {
        return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarsListed);
    }
}