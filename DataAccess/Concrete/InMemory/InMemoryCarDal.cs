using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory;

public class InMemoryCarDal : ICarDal
{
    private readonly List<Car> _cars;

    public InMemoryCarDal()
    {
        _cars = new List<Car>()
        {
            new Car() {CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 100, ModelYear = 2010, Description = "Audi A3"},
            new Car() {CarId = 2, BrandId = 1, ColorId = 2, DailyPrice = 200, ModelYear = 2011, Description = "Audi A4"},
            new Car() {CarId = 3, BrandId = 2, ColorId = 2, DailyPrice = 300, ModelYear = 2012, Description = "BMW 3.20"},
            new Car() {CarId = 4, BrandId = 2, ColorId = 3, DailyPrice = 400, ModelYear = 2013, Description = "BMW 5.20"},
            new Car() {CarId = 5, BrandId = 3, ColorId = 3, DailyPrice = 500, ModelYear = 2014, Description = "Mercedes C180"}
        };

    }
    // public List<Car> GetAll()
    // {
    //     return _cars;
    // }

    public List<Car> GetAll(Expression<Func<Car, bool>>? filter = null)
    {
        return filter == null ? _cars : _cars.Where(filter.Compile()).ToList();
    }

    public Car Get(Expression<Func<Car, bool>> filter)
    {
        return _cars.SingleOrDefault(filter.Compile()) ?? throw new Exception("Car not found!");
    }

    public void Add(Car car)
    {
        _cars.Add(car);
    }

    public void Update(Car car)
    {
        var carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
        if (carToUpdate != null)
        {
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
            
        }
    }

    public void Delete(Car car)
    {
        var carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
        if (carToDelete != null)
        {
            _cars.Remove(carToDelete);
        }
    }

    public List<CarDetailDto> GetCarDetails()
    {
        throw new NotImplementedException();
    }

    public Car GetById(int id)
    {
        return _cars.SingleOrDefault(c => c.CarId == id) ?? throw new Exception("Car not found!");
    }
}