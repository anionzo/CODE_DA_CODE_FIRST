using ANIONZO_API.Constants;
using ANIONZO_API.Entity;
using ANIONZO_API.Models;
using ANIONZO_API.Repository;
using ANIONZO_API.Repository.InterfaceRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ANIONZO_API.Constants.WebApiEndpoint;

namespace ANIONZO_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountController(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [Route(WebApiEndpoint.Account.GetAllAccount)]
        public ActionResult GetAll()
        {
            var accounts = _mapper.Map<List<AccountModel>>(_accountRepository.GetAll());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(accounts);
        }
        [HttpGet]
        [Route(WebApiEndpoint.Account.GetAccount)]
        public IActionResult GetAccount(string Id) {

            var accounts = _mapper.Map<AccountModel>(_accountRepository.Get(Id));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(accounts);
        }
        [HttpPost]
        [Route(WebApiEndpoint.Account.AddAccount)]
        public IActionResult CreateAccount([FromBody] AccountModel accountModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var pokemons = _accountRepository.GetAccountTrimToUpper(accountModel);

            if (pokemons != null)
            {
                ModelState.AddModelError("", "Account Đã tồn tại");
                return StatusCode(422, ModelState);
            }

            var accountMap = _mapper.Map<AccountEntity>(accountModel);
            accountMap.Id = Guid.NewGuid().ToString();

            if (!_accountRepository.Create(accountMap))
            {
                return StatusCode(500, new { error = "Đã xảy ra lỗi trong khi lưu Account." });
            }
            else
                return Ok("Thêm Thành Công!");
        }
        [HttpDelete]
        [Route(WebApiEndpoint.Account.DeleteAccount)]
        public IActionResult DeleteAccount(string Id)
        {

            if (!_accountRepository.GetTExists(Id))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var account = _accountRepository.Get(Id);
            if (!_accountRepository.Delete(account))
            {
                ModelState.AddModelError("", "Something went wrong deleting owner");
            }

            return NoContent();
        }
        [HttpPut]
        [Route(WebApiEndpoint.Account.UpdateAccount)]
        public IActionResult UpdateAccount(string Id,[FromBody] AccountEntity account)
        {
            if (account == null)
                return BadRequest(ModelState);

            if (Id != account.Id)
                return BadRequest(ModelState);

            if (!_accountRepository.GetTExists(Id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var accountMap = _mapper.Map<AccountEntity>(account);

            if (!_accountRepository.Update(accountMap))
            {
                ModelState.AddModelError("", "Đã xảy ra lỗi khi cập nhật");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
