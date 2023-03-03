using Microsoft.AspNetCore.Mvc;
using RecruitmentSITHEC.Helpers.Errors;

namespace RecruitmentSITHEC.Controllers
{
    [Route("errors/{code}")]
    public class ErrorsController : ControllerBase
    { 
        [HttpGet]
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ResponseAPI(code));
        }
    }
}
