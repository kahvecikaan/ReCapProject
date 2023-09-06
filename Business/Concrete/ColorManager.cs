using System.Drawing;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Color = Entities.Concrete.Color;

namespace Business.Concrete;

public class ColorManager : IColorService
{
    private readonly IColorDal _colorDal;

    public ColorManager(IColorDal colorDal)
    {
        _colorDal = colorDal;
    }


    public IDataResult<List<Color>> GetAll()
    {
        return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorsListed);
    }

    public IDataResult<Color> GetById(int id)
    {
        return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == id));
    }

    public IResult Add(Color color)
    {
        if (color.ColorName.Length >= 2)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }
        return new ErrorResult(Messages.ColorNameInvalid);
    }

    public IResult Update(Color color)
    {
        _colorDal.Update(color);
        return new SuccessResult(Messages.ColorUpdated);
    }

    public IResult Delete(Color color)
    {
        _colorDal.Delete(color);
        return new SuccessResult(Messages.ColorDeleted);
    }
}