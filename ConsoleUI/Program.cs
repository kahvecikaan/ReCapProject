using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI;

public class Program
{
    static void Main(string[] args)
    {
        var carManager = new CarManager(new EfCarDal());
                
        // carManager.Add(new Car
        // {
        //     BrandId = 4,
        //     ColorId = 1,
        //     DailyPrice = 100,
        //     CarName = "Mercedes",
        //     Description = "Mercedes C180 2015, Red",
        //     ModelYear = 2015
        // });
                
        var result = carManager.GetAll();
        if (result.Success)
        {
            if (result.Data != null)
            {
                Console.WriteLine(result.Message);
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + " / " + car.Description);
                }
            }
        }
        
        // write a code to test the RentalManager
        
        // var rentalManager = new RentalManager(new EfRentalDal());
        // var result = rentalManager.Add(new Rental
        // {
        //     CarId = 1,
        //     CustomerId = 1,
        //     RentDate = DateTime.Now,
        //     ReturnDate = null
        // });
        // Console.WriteLine(result.Message);
    }
}