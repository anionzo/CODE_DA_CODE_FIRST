using ANIONZO_API.Constants;
using ANIONZO_API.Entity;
using ANIONZO_API.Models;
using ANIONZO_API.Repository.InterfaceRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ANIONZO_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        private readonly IReviewerRepository _reviewerRepository;
        private readonly IPokemonRepository _pokemonRepository;

        public ReviewController(IReviewRepository reviewRepository,
            IMapper mapper,
            IPokemonRepository pokemonRepository,
            IReviewerRepository reviewerRepository)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
            _reviewerRepository = reviewerRepository;
            _pokemonRepository = pokemonRepository;
        }

        [HttpGet]
        [Route(WebApiEndpoint.Review.GetAllReview)]
        public IActionResult GetReviews()
        {
            var reviews = _mapper.Map<List<ReviewModel>>(_reviewRepository.GetALL());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviews);
        }

        [HttpGet]
        [Route(WebApiEndpoint.Review.GetPokemon)]

        public IActionResult GetPokemon(string reviewId)
        {
            if (!_reviewRepository.Exists(reviewId))
                return NotFound();

            var review = _mapper.Map<ReviewModel>(_reviewRepository.Get(reviewId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(review);
        }

        [HttpGet]
        [Route(WebApiEndpoint.Review.GetReviewsForAPokemon)]

        public IActionResult GetReviewsForAPokemon(string pokeId)
        {
            var reviews = _mapper.Map<List<ReviewModel>>(_reviewRepository.GetReviewsOfAPokemon(pokeId));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(reviews);
        }

        [HttpPost]
        [Route(WebApiEndpoint.Review.AddReview)]

        public IActionResult CreateReview([FromQuery] string reviewerId, [FromQuery] string pokeId, [FromBody] ReviewModel reviewCreate)
        {
            if (reviewCreate == null)
                return BadRequest(ModelState);

            var reviews = _reviewRepository.GetALL()
                .Where(c => c.Title.Trim().ToUpper() == reviewCreate.Title.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (reviews != null)
            {
                ModelState.AddModelError("", "Review already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reviewMap = _mapper.Map<ReviewEntity>(reviewCreate);

            reviewMap.Pokemon = _pokemonRepository.GetID(pokeId);
            reviewMap.Reviewer = _reviewerRepository.Get (reviewerId);


            if (!_reviewRepository.Create(reviewMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut]
        [Route(WebApiEndpoint.Review.UpdateReview)]

        public IActionResult UpdateReview(string reviewId, [FromBody] ReviewModel updatedReview)
        {
            if (updatedReview == null)
                return BadRequest(ModelState);

            if (reviewId != updatedReview.Id)
                return BadRequest(ModelState);

            if (!_reviewRepository.Exists(reviewId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var reviewMap = _mapper.Map<ReviewEntity>(updatedReview);

            if (!_reviewRepository.Update(reviewMap))
            {
                ModelState.AddModelError("", "Something went wrong updating review");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete]
        [Route(WebApiEndpoint.Review.DeleteReview)]

        public IActionResult DeleteReview(string reviewId)
        {
            if (!_reviewRepository.Exists(reviewId))
            {
                return NotFound();
            }

            var reviewToDelete = _reviewRepository.Get(reviewId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_reviewRepository.Delete(reviewToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting owner");
            }

            return NoContent();
        }

        // Added missing delete range of reviews by a reviewer **>CK
        [HttpDelete]
        [Route(WebApiEndpoint.Review.DeleteReviewsByReviewer)]

        public IActionResult DeleteReviewsByReviewer(string reviewerId)
        {
            if (!_reviewerRepository.Exists(reviewerId))
                return NotFound();

            var reviewsToDelete = _reviewerRepository.GetReviewsByReviewer(reviewerId).ToList();
            if (!ModelState.IsValid)
                return BadRequest();

            if (!_reviewRepository.DeleteList(reviewsToDelete))
            {
                ModelState.AddModelError("", "error deleting reviews");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
