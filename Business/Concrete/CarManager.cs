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
        // business logic...
        _carDal.Add(car);
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
        // business logic...
        return _carDal.GetById(id);
    }
}