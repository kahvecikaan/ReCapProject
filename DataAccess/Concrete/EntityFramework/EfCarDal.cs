using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework;

public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>,ICarDal
{
    public List<CarDetailDto> GetCarDetails()
    {
        using (CarRentalContext context = new CarRentalContext())
        {
            var result = from c in context.Cars
                join b in context.Brands
                    on c.BrandId equals b.BrandId
                join co in context.Colors
                    on c.ColorId equals co.ColorId
                select new CarDetailDto
                {
                    CarName = c.CarName,
                    BrandName = b.BrandName,
                    ColorName = co.ColorName,
                    DailyPrice = c.DailyPrice
                };
            return result.ToList();
        }
        
        // alternative way of writing the query above
        /*using (CarRentalContext context = new CarRentalContext())
        {
            var result = context.Cars
                .Join(context.Brands,
                    c => c.BrandId,
                    b => b.BrandId,
                    (c, b) => new CarDetailDto
                    {
                        CarName = c.CarName,
                        BrandName = b.BrandName,
                        DailyPrice = c.DailyPrice
                    })
                .Join(context.Colors,
                    c => c.ColorId,
                    co => co.ColorId,
                    (c, co) => new CarDetailDto
                    {
                        CarName = c.CarName,
                        BrandName = c.BrandName,
                        ColorName = co.ColorName,
                        DailyPrice = c.DailyPrice
                    });
            return result.ToList();
        }*/
    }
}