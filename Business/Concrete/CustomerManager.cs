using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete;

public class CustomerManager : ICustomerService
{
    private readonly ICustomerDal _customerDal;

    public CustomerManager(ICustomerDal customerDal)
    {
        _customerDal = customerDal;
    }

    public IDataResult<List<Customer>> GetAll()
    {
        return new SuccessDataResult<List<Customer>>(Messages.CustomersListed);
    }

    public IDataResult<Customer> GetById(int id)
    {
        return new SuccessDataResult<Customer>
            (_customerDal.Get(c => c.CustomerId == id), Messages.CustomersListed);
    }

    public IDataResult<Customer> GetByUserId(int userId)
    {
        return new SuccessDataResult<Customer>
            (_customerDal.Get(c => c.UserId == userId), Messages.CustomersListed);
    }

    public IDataResult<List<CustomerDetailDto>> GetAllCustomerDetails()
    {
        return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetAllCustomerDetails());
    }

    public IResult Add(Customer customer)
    {
        _customerDal.Add(customer);
        return new SuccessResult(Messages.CustomerAdded);
    }

    public IResult Update(Customer customer)
    {
        _customerDal.Update(customer);
        return new SuccessResult(Messages.CustomerUpdated);
    }

    public IResult Delete(Customer customer)
    {
        _customerDal.Delete(customer);
        return new SuccessResult(Messages.CustomerDeleted);
    }
}