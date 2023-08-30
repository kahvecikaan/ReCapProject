using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class EfCarDal : ICarDal
{
    public List<Car> GetAll(Expression<Func<Car, bool>>? filter = null)
    {
        using (CarRentalContext context = new CarRentalContext())
        {
            return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
        }
    }

    public Car Get(Expression<Func<Car, bool>> filter)
    {
        using (CarRentalContext context = new CarRentalContext())
        {
            return context.Set<Car>().SingleOrDefault(filter) ?? throw new Exception("NULL");
        }
    }

    public void Add(Car entity)
    {
        using (CarRentalContext context = new CarRentalContext())
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }
    }

    public void Update(Car entity)
    {
        using (CarRentalContext context = new CarRentalContext())
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }

    public void Delete(Car entity)
    {
        using (CarRentalContext context = new CarRentalContext())
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}