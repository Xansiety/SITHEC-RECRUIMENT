using Microsoft.AspNetCore.Mvc;
using RecruitmentSITHEC.DTOs.Operations;
using RecruitmentSITHEC.Helpers.Abstracts;
using RecruitmentSITHEC.Helpers.Constantes;
using RecruitmentSITHEC.Helpers.Errors;

namespace RecruitmentSITHEC.Controllers
{
    [Route("api/operaciones")]
    [ApiController]
    public class OperationsController : ControllerBase
    {

        [HttpPost("MathOperation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Addition([FromBody] OperationValues values)
        {
            double result = 0;

            if (values is null) return BadRequest(new ResponseAPI(400, "No values, please add"));
             
            switch (values.Operator)
            {
                case Operadores.addition:
                    AdditionCalculation additionCalculation = new AdditionCalculation(values.a, values.b);
                    result = additionCalculation.Calculate();
                    break;
                case Operadores.subtraction:
                    SubtractionCalculation subtractionCalculation = new SubtractionCalculation(values.a, values.b);
                    result = subtractionCalculation.Calculate();
                    break;
                case Operadores.multiplication:
                    MultiplicationCalculation multiplicationCalculation = new MultiplicationCalculation(values.a, values.b);
                    result = multiplicationCalculation.Calculate();
                    break;
                case Operadores.division:

                    double[] valuesArr = new double[] { values.a, values.b };
                    if (valuesArr.Contains(0)) return BadRequest(new ResponseAPI(400, "The division by zero is not allowed"));

                    DivisionCalculation divisionCalculation = new DivisionCalculation(values.a, values.b);
                    result = divisionCalculation.Calculate();
                    break;
                default:
                    return BadRequest(new ResponseAPI(400, "Please enter a valid operator"));
            }
            return Ok(new ResponseAPI(200, $"Result: {result} ", true));
        }



    }
}
