using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI;

public class Program
{
    static void Main(string[] args)
    {
        var carManager = new CarManager(new EfCarDal());
        
        carManager.Add(new Car
        {
            BrandId = 4,
            ColorId = 1,
            DailyPrice = 100,
            CarName = "Mercedes",
            Description = "Mercedes C180 2015, Red",
            ModelYear = 2015
        });
        
        foreach(var car in carManager.GetAll())
        {
            Console.WriteLine(car.Description);
        }
    }
}