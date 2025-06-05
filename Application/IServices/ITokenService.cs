using Domain;

namespace Application.IServices
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
}
