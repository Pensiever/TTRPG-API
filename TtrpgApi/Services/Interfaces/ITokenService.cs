using TtrpgApi.Models;

namespace TtrpgApi.Services.Interfaces
{
    public interface ITokenService
    {
        ConnectedQuester Authenticate(string username, string password);
    }
}
