using Core.Entities;

namespace Entities.DTOs;

public class UserForLoginDto : IDto
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}