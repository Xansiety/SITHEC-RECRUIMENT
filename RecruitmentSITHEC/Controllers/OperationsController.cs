using Microsoft.AspNetCore.Mvc; 
using RecruitmentSITHEC.DTOs.Operations;
using RecruitmentSITHEC.Helpers.Abstracts;
using RecruitmentSITHEC.Helpers.Errors;

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
            Addition addition = new Addition();
            double result = addition.Calculate(values.a, values.b, values.c);
            return Ok(new ResponseAPI(200, $"Result: {result} ", true));
        }

        [HttpPost("Resta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Subtraction([FromBody] OperationValues values)
        {
            Subtraction subtraction = new Subtraction();
            double result = subtraction.Calculate(values.a, values.b, values.c);
            return Ok(new ResponseAPI(200, $"Result: {result} ", true));
        }

        [HttpPost("Multiplicación")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Multiplication([FromBody] OperationValues values)
        {
            Multiplication multiplication = new Multiplication();
            double result = multiplication.Calculate(values.a, values.b, values.c);
            return Ok(new ResponseAPI(200, $"Result: {result} ", true));
        }

        [HttpPost("División")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Division([FromBody] OperationValues values)
        { 
            double[] valuesArr = { values.a, values.b, values.c };
            if (valuesArr.Contains(0)) return BadRequest(new ResponseAPI(400, "The division by zero is not allowed", false));

            Division division = new Division();
            double result = division.Calculate(values.a, values.b, values.c);
            return Ok(new ResponseAPI(200, $"Result: {result} ", true));
        }

    }
}
