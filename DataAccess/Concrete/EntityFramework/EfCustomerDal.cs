using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework;

public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarRentalContext>, ICustomerDal
{
    public List<CustomerDetailDto> GetAllCustomerDetails()
    {
        using (CarRentalContext context = new CarRentalContext())
        {
            var result = from c in context.Customers
                join u in context.Users on c.UserId equals u.UserId
                select new CustomerDetailDto
                {
                    CustomerId = c.CustomerId,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    CompanyName = c.CompanyName
                };
            return result.ToList();
        }
    }
}