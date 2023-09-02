using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface ICarService
{
    IDataResult<List<Car>> GetAll();
    IResult Add(Car car);
    IResult Update(Car car);
    IResult Delete(Car car);
    IDataResult<Car> GetByCarId(int carId);
    IDataResult<List<Car>> GetCarsByBrandId(int id);
    IDataResult<List<Car>> GetCarsByColorId(int id);
    IDataResult<List<CarDetailDto>> GetCarDetails();
}