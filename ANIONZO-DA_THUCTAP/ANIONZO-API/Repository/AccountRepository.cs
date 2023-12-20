using ANIONZO_API.Entity;
using ANIONZO_API.Models;
using ANIONZO_API.Repository.InterfaceRepository;

namespace ANIONZO_API.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDataContext _context;

        public AccountRepository(AppDataContext context)
        {
            _context = context;
        }
        public bool Create(AccountEntity account)
        {
            _context.Add(account);
            return Save();
        }

        public bool Delete(AccountEntity account)
        {
            _context.Remove(account);
            return Save();
        }

        public AccountEntity Get(string Id)
        {
            var account = _context.Accounts.FirstOrDefault(x => x.Id == Id);
            return account;
        }

        public AccountEntity GetAccountTrimToUpper(AccountModel account)
        {
            return GetAll().Where(c => c.Username.Trim().ToUpper() == account.Username.TrimEnd().ToUpper())
                           .FirstOrDefault();
        }

        public ICollection<AccountEntity> GetAll()
        {
            return _context.Accounts.ToList();
        }

        public bool GetTExists(string Id)
        {
            return _context.Accounts.Any(x => x.Id == Id);
        }

        public bool Login(AccountModel account)
        {
            return _context.Accounts.Any(x => x.Username == account.Username && x.PasswordHash == account.PasswordHash); ;
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool Update(AccountEntity account)
        {
            _context.Update(account);
            return Save();
        }
    }
}
