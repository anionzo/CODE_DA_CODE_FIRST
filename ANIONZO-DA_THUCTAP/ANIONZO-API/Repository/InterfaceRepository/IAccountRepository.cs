using ANIONZO_API.Entity;
using ANIONZO_API.Models;

namespace ANIONZO_API.Repository.InterfaceRepository
{
    public interface IAccountRepository
    {
        ICollection<AccountEntity> GetAll();
        AccountEntity Get(string Id);
        bool Login(AccountModel account);
        bool GetTExists(string Id);
        AccountEntity GetAccountTrimToUpper(AccountModel account);
        bool Create(AccountEntity account);
        bool Update(AccountEntity account);
        bool Delete(AccountEntity account);
        bool Save();
    }
}
