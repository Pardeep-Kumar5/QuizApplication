using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApplicationBackend.Data;
using QuizApplicationBackend.Repository.IRepository;

namespace QuizApplicationBackend.Controllers
{
    [Route("Category")]
    [ApiController]
    public class CategroyController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategroyController(ICategoryRepository categoryRepository)
        {
            _categoryRepository=categoryRepository;
        }
        [HttpGet("GetAllCategory")]
        public IActionResult GetAllCategory()
        {
            var data = _categoryRepository.GetAllCategory();
            return Ok(data);
        }
        [HttpGet("GetCategorybyId")]
        public IActionResult GetCategory(int categoryId)
        {
            var data=_categoryRepository.GetCategoryById(categoryId);
            return Ok(data);
        }

    }
}
