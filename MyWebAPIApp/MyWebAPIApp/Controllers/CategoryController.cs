using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPIApp.Data;
using MyWebAPIApp.Interface;
using MyWebAPIApp.Models;
using MyWebAPIApp.Models.ViewModel;

namespace MyWebAPIApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(_categoryRepository.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                var find = _categoryRepository.GetById(id);
                if (find == null)
                {
                    return NotFound();
                }
                return Ok(find);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, CategoryVM categoryVM)
        {
            if (id != categoryVM.CategoryID)
            {
                return BadRequest();
            }
            try
            {
                _categoryRepository.Update(categoryVM);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _categoryRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        //[Authorize]
        public ActionResult Add(CategoryModel categoryModel)
        {
            try
            {
                return Ok(_categoryRepository.Create(categoryModel));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
