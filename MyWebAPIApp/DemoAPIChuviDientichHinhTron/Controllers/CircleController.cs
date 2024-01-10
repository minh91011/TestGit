using DemoAPIChuviDientichHinhTron.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPIChuviDientichHinhTron.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CircleController : ControllerBase
    {
        [HttpGet("radius")]
        public IActionResult CalculateCircleProperties(double radius)
        {
            if (radius <= 0)
            {
                return BadRequest("Invalid radius. Radius must be greater than zero.");
            }

            double perimeter = 2 * Math.PI * radius;
            double area = Math.PI * radius * radius;

            var result = new
            {
                Radius = radius,
                Perimeter = perimeter,
                Area = area
            };

            return Ok(result);
        }
    }
}
