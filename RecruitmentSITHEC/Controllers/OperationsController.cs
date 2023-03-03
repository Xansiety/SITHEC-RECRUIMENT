using Microsoft.AspNetCore.Mvc;
using RecruitmentSITHEC.DTO_s.Operations;

namespace RecruitmentSITHEC.Controllers
{
    [Route("api/operaciones")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        [HttpPost("Suma")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Addition([FromBody] OperationValues values)
        {
            int result = values.a + values.b + values.c;
            return Ok(result);
        }

        [HttpPost("Resta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Subtraction([FromBody] OperationValues values)
        {
            int result = values.a - values.b - values.c;
            return Ok(result);
        }

        [HttpPost("Multiplicación")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Multiplication([FromBody] OperationValues values)
        {
            int result = values.a * values.b * values.c;
            return Ok(result);
        }

        [HttpPost("División")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Division([FromBody] OperationValues values)
        {
            int result = values.a / values.b / values.c;
            return Ok(result); 
        }

    }
}
