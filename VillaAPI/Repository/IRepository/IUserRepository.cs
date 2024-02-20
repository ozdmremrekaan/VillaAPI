using VillaAPI.Models;
using VillaAPI.Models.Dto.Auth;

namespace VillaAPI.Repository.IRepository
{
    public interface IUserRepository
    {
        bool isUniqueUser (string username);
        Task<LoginResponseDto> Login (LoginRequestDto loginRequestDto);
        Task<UserDto> Register(RegistrationRequestDto registrationRequestDto);
    }
}
