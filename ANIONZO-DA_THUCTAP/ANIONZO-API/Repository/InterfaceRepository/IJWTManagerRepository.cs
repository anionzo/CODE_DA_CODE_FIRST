using ANIONZO_API.Models;

namespace ANIONZO_API.Repository.InterfaceRepository
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(AccountModel account);
    }
}
