using Excercise2_PRN231_MinhNNHE161638.Interface;
using Excercise2_PRN231_MinhNNHE161638.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Excercise2_PRN231_MinhNNHE161638.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_studentRepository.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Add(StudentModel studentModel) {
            try
            {
                return Ok(_studentRepository.Create(studentModel));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
