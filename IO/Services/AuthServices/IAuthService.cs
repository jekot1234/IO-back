using IO.Model;

namespace IO.Services.AuthServices
{
    public interface IAuthService
    {
        User Authenticate(string email, string password);
    }
}