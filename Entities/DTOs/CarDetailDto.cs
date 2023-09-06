using Core.Entities;

namespace Entities.DTOs;

public class CarDetailDto : IDto
{
    public string? CarName { get; set; }
    public string BrandName { get; set; } = string.Empty;
    public string ColorName { get; set; } = string.Empty;
    public int DailyPrice { get; set; }
}