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
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerRepository _OwnerRepository;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerRepository OwnerRepository, IMapper mapper)
        {
            _OwnerRepository = OwnerRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [Route(WebApiEndpoint.Owner.GetAllOwner)]
        public IActionResult GetAll()
        {
            var Owners = _mapper.Map<List<OwnerModel>>(_OwnerRepository.GetAll());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Owners);
        }
        [HttpGet]
        [Route(WebApiEndpoint.Owner.GetOwner)]
        public IActionResult Get(string Id)
        {
            if (!_OwnerRepository.OwnerExists(Id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var Owner = _mapper.Map<OwnerModel>(_OwnerRepository.Get(Id));
            return Ok(Owner);
        }
        [HttpPost]
        [Route(WebApiEndpoint.Owner.AddOwner)]
        public IActionResult Create([FromBody] OwnerModel OwnerCreate)
        {
            if (OwnerCreate == null)
                return BadRequest(ModelState);

            var Owner = _OwnerRepository.GetAll()
                .Where(c => c.FirstName.Trim().ToUpper() == OwnerCreate.FirstName.TrimEnd().ToUpper() ||
                            c.LastName.Trim().ToUpper() == OwnerCreate.LastName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (Owner != null)
            {
                ModelState.AddModelError("", "Owner đã tồn tại");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var OwnerMap = _mapper.Map<OwnerEntity>(OwnerCreate);
            OwnerMap.Id = Guid.NewGuid().ToString();

            if (!_OwnerRepository.Create(OwnerMap))
            {
                ModelState.AddModelError("", "Đã xảy ra lỗi trong khi save");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut]
        [Route(WebApiEndpoint.Owner.UpdateOwner)]
        public IActionResult Update(string Id, [FromBody] OwnerModel updatedOwner)
        {
            if (updatedOwner == null)
                return BadRequest(ModelState);

            if (Id != updatedOwner.Id)
                return BadRequest(ModelState);

            if (!_OwnerRepository.OwnerExists(Id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var OwnerMap = _mapper.Map<OwnerEntity>(updatedOwner);

            if (!_OwnerRepository.Update(OwnerMap))
            {
                ModelState.AddModelError("", "Lỗi trong quá trình update Owner");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [HttpGet]
        [Route(WebApiEndpoint.Owner.GetPokemonByOwner)]

        public IActionResult GetPokemonByOwner(string ownerId)
        {
            if (!_OwnerRepository.OwnerExists(ownerId))
            {
                return NotFound();
            }

            var owner = _mapper.Map<List<PokemonModel>>(
                _OwnerRepository.GetPokemonByOwner(ownerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(owner);
        }
        [HttpDelete]
        [Route(WebApiEndpoint.Owner.DeleteOwner)]
        public IActionResult Delete(string Id)
        {
            if (!_OwnerRepository.OwnerExists(Id))
            {
                return NotFound();
            }

            var OwnerToDelete = _OwnerRepository.Get(Id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_OwnerRepository.Delete(OwnerToDelete))
            {
                ModelState.AddModelError("", "Lỗi trong việc xóa Owner");
            }

            return Ok("Xóa thành công");
        }
    }
}
