using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface ICustomerService
{
    IDataResult<List<Customer>> GetAll();
    IDataResult<Customer> GetById(int id);
    IDataResult<Customer> GetByUserId(int userId);
    IDataResult<List<CustomerDetailDto>> GetAllCustomerDetails();
    IResult Add(Customer customer);
    IResult Update(Customer customer);
    IResult Delete(Customer customer);
}