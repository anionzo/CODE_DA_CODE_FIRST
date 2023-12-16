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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper) {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryEntity>))]
        [Route(WebApiEndpoint.Category.GetAllCategory)]
        public IActionResult GetAll() {
            var categorys = _mapper.Map<List<CategoryModel>>(_categoryRepository.GetAll());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(categorys);
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PokemonModel>))]
        [Route(WebApiEndpoint.Category.GetCategory)]
        public IActionResult Get(string Id)
        {
            if (!_categoryRepository.GetTExists(Id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var category = _mapper.Map<CategoryModel>(_categoryRepository.Get(Id));
            return Ok(category);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [Route(WebApiEndpoint.Category.AddCategory)]

        public IActionResult Create([FromBody] CategoryModel categoryCreate)
        {
            if (categoryCreate == null)
                return BadRequest(ModelState);

            var category = _categoryRepository.GetAll()
                .Where(c => c.Name.Trim().ToUpper() == categoryCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (category != null)
            {
                ModelState.AddModelError("", "Category đã tồn tại");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryMap = _mapper.Map<CategoryEntity>(categoryCreate);
            categoryMap.Id = Guid.NewGuid().ToString();

            if (!_categoryRepository.Create(categoryMap))
            {
                ModelState.AddModelError("", "Đã xảy ra lỗi trong khi save");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [Route(WebApiEndpoint.Category.UpdateCategory)]

        public IActionResult Update(string Id, [FromBody] CategoryModel updatedCategory)
        {
            if (updatedCategory == null)
                return BadRequest(ModelState);

            if (Id != updatedCategory.Id)
                return BadRequest(ModelState);

            if (!_categoryRepository.GetTExists(Id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var categoryMap = _mapper.Map<CategoryEntity>(updatedCategory);

            if (!_categoryRepository.Update(categoryMap))
            {
                ModelState.AddModelError("", "Lỗi trong quá trình update category");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [Route(WebApiEndpoint.Category.DeleteCategory)]
        public IActionResult Delete(string Id)
        {
            if (!_categoryRepository.GetTExists(Id))
            {
                return NotFound();
            }

            var categoryToDelete = _categoryRepository.Get(Id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_categoryRepository.Delete(categoryToDelete))
            {
                ModelState.AddModelError("", "Lỗi trong việc xóa category");
            }

            return Ok("Xóa thành công");
        }

    }
}
