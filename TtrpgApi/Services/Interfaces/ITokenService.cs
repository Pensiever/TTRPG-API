using TtrpgApi.Models;

namespace TtrpgApi.Services.Interfaces
{
    public interface ITokenService
    {
        ConnectedQuester Authenticate(string email, string password);
    }
}
