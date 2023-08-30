using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class EfColorDal : IColorDal
{
    public List<Color> GetAll(Expression<Func<Color, bool>>? filter = null)
    {
        using (CarRentalContext context = new CarRentalContext())
        {
            return filter == null ? context.Set<Color>().ToList() : context.Set<Color>().Where(filter).ToList();
        }
    }

    public Color Get(Expression<Func<Color, bool>> filter)
    {
        using (CarRentalContext context = new CarRentalContext())
        {
            return context.Set<Color>().SingleOrDefault(filter) ?? throw new Exception("NULL");
        }
    }

    public void Add(Color entity)
    {
        using (CarRentalContext context = new CarRentalContext())
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }
    }

    public void Update(Color entity)
    {
        using (CarRentalContext context = new CarRentalContext())
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }

    public void Delete(Color entity)
    {
        using (CarRentalContext context = new CarRentalContext())
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}