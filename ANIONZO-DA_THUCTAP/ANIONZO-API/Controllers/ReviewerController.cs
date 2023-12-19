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
    public class ReviewerController : ControllerBase
    {
        private readonly IReviewerRepository _reviewerRepository;
        private readonly IMapper _mapper;

        public ReviewerController(IReviewerRepository reviewerRepository, IMapper mapper)
        {
            _reviewerRepository = reviewerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route(WebApiEndpoint.Reviewer.GetAllReviewer)]
        public IActionResult GetReviewers()
        {
            var reviewers = _mapper.Map<List<ReviewerModel>>(_reviewerRepository.GetAll());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviewers);
        }

        [HttpGet]
        [Route(WebApiEndpoint.Reviewer.GetReviewer)]
        public IActionResult GetPokemon(string reviewerId)
        {
            if (!_reviewerRepository.Exists(reviewerId))
                return NotFound();

            var reviewer = _mapper.Map<ReviewerModel>(_reviewerRepository.Get(reviewerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviewer);
        }

        [HttpGet]
        [Route(WebApiEndpoint.Reviewer.GetReviewsByAReviewer)]

        public IActionResult GetReviewsByAReviewer(string reviewerId)
        {
            if (!_reviewerRepository.Exists(reviewerId))
                return NotFound();

            var reviews = _mapper.Map<List<ReviewModel>>(
                _reviewerRepository.GetReviewsByReviewer(reviewerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviews);
        }

        [HttpPost]
        [Route(WebApiEndpoint.Reviewer.AddReviewer)]

        public IActionResult CreateReviewer([FromBody] ReviewerModel reviewerCreate)
        {
            if (reviewerCreate == null)
                return BadRequest(ModelState);

            var country = _reviewerRepository.GetAll()
                .Where(c => c.LastName.Trim().ToUpper() == reviewerCreate.LastName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (country != null)
            {
                ModelState.AddModelError("", "Country already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reviewerMap = _mapper.Map<ReviewerEntity>(reviewerCreate);

            if (!_reviewerRepository.Create(reviewerMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut]
        [Route(WebApiEndpoint.Reviewer.UpdateReviewer)]

        public IActionResult UpdateReviewer(string reviewerId, [FromBody] ReviewerModel updatedReviewer)
        {
            if (updatedReviewer == null)
                return BadRequest(ModelState);

            if (reviewerId != updatedReviewer.Id)
                return BadRequest(ModelState);

            if (!_reviewerRepository.Exists(reviewerId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var reviewerMap = _mapper.Map<ReviewerEntity>(updatedReviewer);

            if (!_reviewerRepository.Update(reviewerMap))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        [HttpDelete]
        [Route(WebApiEndpoint.Reviewer.DeleteReviewer)]

        public IActionResult DeleteReviewer(string reviewerId)
        {
            if (!_reviewerRepository.Exists(reviewerId))
            {
                return NotFound();
            }

            var reviewerToDelete = _reviewerRepository.Get(reviewerId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_reviewerRepository.Delete(reviewerToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting reviewer");
            }

            return NoContent();
        }
    }
}
