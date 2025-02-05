using Microsoft.AspNetCore.Mvc;

namespace CircleCalculator.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class CircleController : ControllerBase
    {
        [HttpGet("{r}")]
        public IActionResult Calculate(double r)
        {
            if (r <= 0)
            {
                return BadRequest("Bán kính phải lớn hơn 0");
            }

            var result = new
            {
                dien_tich = Math.PI * r * r,
                chu_vi = 2 * Math.PI * r,
                duong_kinh = 2 * r
            };

            return Ok(result);
        }
    }
}