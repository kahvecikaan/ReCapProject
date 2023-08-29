using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CarManager : ICarService
{
    private readonly ICarDal _carDal;

    public CarManager(ICarDal carDal)
    {
        _carDal = carDal;
    }

    public List<Car> GetAll()
    {
        // business logic...
        return _carDal.GetAll();
    }

    public void Add(Car car)
    {
        if(car.Description.Length >= 2 && car.DailyPrice > 0)
            _carDal.Add(car);
        else
            throw new Exception("Car name must be at least 2 characters and daily price must be greater than 0.");
    }

    public void Update(Car car)
    {
        // business logic...
        _carDal.Update(car);
    }

    public void Delete(Car car)
    {
        // business logic...
        _carDal.Delete(car);
    }
    
    public Car GetById(int id)
    {
        return _carDal.Get(c => c.Id == id);
    }

    public List<Car> GetCarsByBrandId(int id)
    {
        return _carDal.GetAll(c => c.BrandId == id);
    }

    public List<Car> GetCarsByColorId(int id)
    {
        return _carDal.GetAll(c => c.ColorId == id);
    }
}