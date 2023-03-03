using Microsoft.AspNetCore.Mvc;

namespace RecruitmentSITHEC.Controllers
{
    [Route("api/humano")]
    [ApiController]
    public class HumanController : ControllerBase
    { 
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { msg = "I'm Human" });
        }
    }
}
