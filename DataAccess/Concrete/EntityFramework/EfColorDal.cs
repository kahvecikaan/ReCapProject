using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class EfColorDal : IColorDal
{
    public List<Color> GetAll(Expression<Func<Color, bool>>? filter = null)
    {
        using (RentalServiceContext context = new RentalServiceContext())
        {
            return filter == null ? context.Set<Color>().ToList() : context.Set<Color>().Where(filter).ToList();
        }
    }

    public Color Get(Expression<Func<Color, bool>> filter)
    {
        using (RentalServiceContext context = new RentalServiceContext())
        {
            return context.Set<Color>().SingleOrDefault(filter) ?? throw new Exception("NULL");
        }
    }

    public void Add(Color entity)
    {
        using (RentalServiceContext context = new RentalServiceContext())
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }
    }

    public void Update(Color entity)
    {
        using (RentalServiceContext context = new RentalServiceContext())
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }

    public void Delete(Color entity)
    {
        using (RentalServiceContext context = new RentalServiceContext())
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}