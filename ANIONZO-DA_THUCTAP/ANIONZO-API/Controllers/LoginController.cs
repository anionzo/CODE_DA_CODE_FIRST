using ANIONZO_API.Constants;
using ANIONZO_API.Models;
using ANIONZO_API.Repository;
using ANIONZO_API.Repository.InterfaceRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ANIONZO_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IJWTManagerRepository _jWTManagerRepository;
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;

        public LoginController(IJWTManagerRepository jWTManagerRepository, IMapper mapper, IAccountRepository accountRepository)
        {
            _jWTManagerRepository = jWTManagerRepository;
            _mapper = mapper;
            _accountRepository = accountRepository;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route(WebApiEndpoint.Login.Authenticate)]
        public IActionResult Authenticate(AccountModel account)
        {
            var token = _jWTManagerRepository.Authenticate(account);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
        [HttpGet]
        [Route(WebApiEndpoint.Login.GetAllLogin)]
        public ActionResult GetAll()
        {
            var accounts = _mapper.Map<List<AccountModel>>(_accountRepository.GetAll());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(accounts);
        }
    }
}
