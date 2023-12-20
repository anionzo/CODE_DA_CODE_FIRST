using ANIONZO_API.Constants;
using ANIONZO_API.Entity;
using ANIONZO_API.Models;
using ANIONZO_API.Repository.InterfaceRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ANIONZO_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [Route(WebApiEndpoint.Country.GetAllCountry)]
        public IActionResult GetAll()
        {
            var countries = _mapper.Map<List<CountryModel>>(_countryRepository.GetAll());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(countries);
        }

        [HttpGet]
        //[ProducesResponseType(200, Type = typeof(CountryEntity))]
        //[ProducesResponseType(400)]
        [Route(WebApiEndpoint.Country.GetCountry)]

        public IActionResult GetCountry(string countryId)
        {
            if (!_countryRepository.Exists(countryId))
                return NotFound();

            var country = _mapper.Map<CountryModel>(_countryRepository.Get(countryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(country);
        }

        [HttpGet]
        [Route(WebApiEndpoint.Country.GetCountryOfAnOwner)]

        public IActionResult GetCountryOfAnOwner(string ownerId)
        {
            var country = _mapper.Map<CountryModel>(
                _countryRepository.GetCountryByOwner(ownerId));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(country);
        }

        [HttpPost]
        [Route(WebApiEndpoint.Country.AddCountry)]

        public IActionResult CreateCountry([FromBody] CountryModel countryCreate)
        {
            if (countryCreate == null)
                return BadRequest(ModelState);

            var country = _countryRepository.GetAll()
                .Where(c => c.Name.Trim().ToUpper() == countryCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (country != null)
            {
                ModelState.AddModelError("", "Country already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var countryMap = _mapper.Map<CountryEntity>(countryCreate);

            if (!_countryRepository.Create(countryMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut]
        [Route(WebApiEndpoint.Country.UpdateCountry)]
        public IActionResult UpdateCategory(string countryId, [FromBody] CountryModel updatedCountry)
        {
            if (updatedCountry == null)
                return BadRequest(ModelState);

            if (countryId != updatedCountry.Id)
                return BadRequest(ModelState);

            if (!_countryRepository.Exists(countryId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var countryMap = _mapper.Map<CountryEntity>(updatedCountry);

            if (!_countryRepository.Update(countryMap))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete]
        [Route(WebApiEndpoint.Country.DeleteCountry)]

        public IActionResult DeleteCountry(string countryId)
        {
            if (!_countryRepository.Exists(countryId))
            {
                return NotFound();
            }

            var countryToDelete = _countryRepository.Get(countryId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_countryRepository.Delete(countryToDelete)){        
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }
    }
}
