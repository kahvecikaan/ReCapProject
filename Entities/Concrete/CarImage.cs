using Core.Entities;

namespace Entities.Concrete;

public class CarImage : IEntity
{
    public int CarImageId { get; set; }
    public int CarId { get; set; }
    public string ImagePath { get; set; } = String.Empty;
    public string Date { get; set; } = String.Empty;
}