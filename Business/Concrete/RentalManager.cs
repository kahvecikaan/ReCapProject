using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class RentalManager : IRentalService
{
    private readonly IRentalDal _rentalDal;
        
    public RentalManager(IRentalDal rentalDal)
    {
        _rentalDal = rentalDal;
    }
    
    public IDataResult<List<Rental>> GetAll()
    {
        return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
    }

    public IDataResult<Rental> GetByCustomerId(int id)
    {
        return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.CustomerId == id), Messages.RentalsListed);
    }

    public IResult Add(Rental rental)
    {
        // to rent the car, the car must be returned first (check if return date is null)
        var result = _rentalDal.GetAll(r => r.CarId == rental.CarId && r.ReturnDate == null);
        if (result.Count > 0)
        {
            return new ErrorResult(Messages.RentalNotAdded);
        }
        _rentalDal.Add(rental);
        return new SuccessResult(Messages.RentalAdded);
    }

    public IResult Update(Rental rental)
    {
        return new SuccessResult(Messages.RentalUpdated);
    }

    public IResult Delete(Rental rental)
    {
        return new SuccessResult(Messages.RentalDeleted);
    }
}