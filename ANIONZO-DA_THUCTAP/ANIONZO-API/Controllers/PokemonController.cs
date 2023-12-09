using ANIONZO_API.Constants;
using ANIONZO_API.Entity;
using ANIONZO_API.Models;
using ANIONZO_API.Repository.InterfaceRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ANIONZO_API.Constants.WebApiEndpoint;

namespace ANIONZO_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;

        public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper){
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PokemonEntity>))]
        [Route(WebApiEndpoint.Pokemon.GetAllPokemon)]
        public IActionResult GetAll()
        {
           
            var pokemons = _mapper.Map <List<PokemonModel>>(_pokemonRepository.GetAll());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pokemons);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PokemonModel>))]
        [Route(WebApiEndpoint.Pokemon.GetPokemon)]
        public IActionResult GetPokemon(string Id)
        {
            if (!_pokemonRepository.GetTExists(Id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pokemon = _pokemonRepository.GetID(Id);
            //var pokemon = _mapper.Map<PokemonModel>(_pokemonRepository.GetID(Id));
            return Ok(pokemon);
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<decimal>))]
        [Route(WebApiEndpoint.Pokemon.GetRatings)]
        public IActionResult GetRattings(string Id)
        {
            if (!_pokemonRepository.GetTExists(Id))
                return NotFound();
            //var rating = _mapper.Map<List<PokemonModel>>(_pokemonRepository.GetRatings(Id));
            var rating = _pokemonRepository.GetRatings(Id);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(rating);
        }
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PokemonEntity>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [Route(WebApiEndpoint.Pokemon.AddPokemon)]
        public IActionResult CreatePokemon([FromQuery] string ownerId, [FromQuery] string catId, [FromBody] PokemonModel pokemonCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pokemons = _pokemonRepository.GetPokemonTrimToUpper(pokemonCreate);

            if (pokemons != null)
            {
                ModelState.AddModelError("", "Pokemon Đã tồn tại");
                return StatusCode(422, ModelState);
            }

            var pokemonMap = _mapper.Map<PokemonEntity>(pokemonCreate);

            pokemonMap.Id = Guid.NewGuid().ToString();

            if (!_pokemonRepository.CreatePokemon(ownerId, catId, pokemonMap))
            {
                return StatusCode(500, new { error = "Đã xảy ra lỗi trong khi lưu Pokemon." });
            }
            else
                return Ok("Thêm Thành Công!");
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [Route(WebApiEndpoint.Pokemon.UpdatePokemon)]
        public IActionResult UpdatePokemon(string Id, string ownerId, string categoryId, [FromBody] PokemonModel updatedPokemon)
        {
            if (updatedPokemon == null)
                return BadRequest(ModelState);

            if (Id != updatedPokemon.Id)
                return BadRequest(ModelState);

            if (!_pokemonRepository.GetTExists(Id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var pokemonMap = _mapper.Map<PokemonEntity>(updatedPokemon);

            if (!_pokemonRepository.UpdatePokemon(ownerId, categoryId, pokemonMap))
            {
                ModelState.AddModelError("", "Đã xảy ra lỗi khi cập nhật chủ sở hữu");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [Route(WebApiEndpoint.Pokemon.DeletePokemon)]

        public IActionResult DeletePokemon(string Id)
        {
            if (!_pokemonRepository.GetTExists(Id))
            {
                return NotFound();
            }

            //var reviewsToDelete = _reviewRepository.GetReviewsOfAPokemon(pokeId);
            //var pokemonToDelete = _pokemonRepository.GetPokemon(pokeId);

            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            //if (!_reviewRepository.DeleteReviews(reviewsToDelete.ToList()))
            //{
            //    ModelState.AddModelError("", "Something went wrong when deleting reviews");
            //}

            //if (!_pokemonRepository.DeletePokemon(pokemonToDelete))
            //{
            //    ModelState.AddModelError("", "Something went wrong deleting owner");
            //}

            return NoContent();
        }
    }
}
