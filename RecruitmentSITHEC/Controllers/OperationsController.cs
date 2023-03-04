using Microsoft.AspNetCore.Mvc;
using RecruitmentSITHEC.DTOs.Operations;
using RecruitmentSITHEC.Helpers.Abstracts;
using RecruitmentSITHEC.Helpers.Constantes;
using RecruitmentSITHEC.Helpers.Errors;
using RecruitmentSITHEC.Repository.Interfaces;

namespace RecruitmentSITHEC.Controllers
{
    [Route("api/operations")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        private readonly ICalculateService _calculateService;

        public OperationsController(ICalculateService calculateService)
        {
            _calculateService = calculateService;
        }

        private bool IsValidOperator(string operatorValue)
        {
            string[] validOperators = { Operadores.addition, Operadores.subtraction, Operadores.multiplication, Operadores.division };
            return validOperators.Contains(operatorValue);
        }

        private bool IsValidDivision(OperationValues values)
        {
            if (values.Operator == Operadores.division)
            {
                double[] valuesArr = new double[] { values.a, values.b };
                if (valuesArr.Contains(0)) return false;
            }
            return true;
        }


        [HttpPost("MathOperationBodyArguments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CalculateValues([FromBody] OperationValues values)
        {
            bool isValidOperator = IsValidOperator(values.Operator);
            if (!isValidOperator) return BadRequest(new ResponseAPI(400, "Invalid operator."));

            bool isValidDivision = IsValidDivision(values);
            if (!isValidDivision) return BadRequest(new ResponseAPI(400, "The division by zero is not allowed"));

            var operation = GetOperationType(values);
            operation.Operator = Operadores.addition;
            double result = _calculateService.CalculateResult(operation);
            return Ok(new ResponseAPI(200, $"El resultado de la operación {values.a} {values.Operator} {values.b} es: {result}", true));
        }

        [HttpGet("MathOperationFromHeaders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CalculateValues([FromHeader] double a, [FromHeader] double b, [FromHeader] string type)
        {
            bool isValidOperator = IsValidOperator(type);
            if (!isValidOperator) return BadRequest(new ResponseAPI(400, "Invalid operator, please add a operator in your headers."));

            bool isValidDivision = IsValidDivision(new OperationValues { a = a, b = b, Operator = type });
            if (!isValidDivision) return BadRequest(new ResponseAPI(400, "The division by zero is not allowed"));

            var operation = GetOperationType(new OperationValues { a = a, b = b, Operator = type });
            double result = _calculateService.CalculateResult(operation);

            Response.Headers.Add("x-operation-result", result.ToString());
            return Ok(new ResponseAPI(200, $"El resultado de la operación {a} {type} {b} es: {result}", true));
        }

        private Operation GetOperationType(OperationValues values)
        {
            switch (values.Operator)
            {
                case Operadores.addition:
                    return new Addition { a = values.a, b = values.b };
                case Operadores.subtraction:
                    return new Subtraction { a = values.a, b = values.b };
                case Operadores.multiplication:
                    return new Multiplication { a = values.a, b = values.b };
                case Operadores.division:
                    return new Division { a = values.a, b = values.b };
                default:
                    throw new InvalidOperationException("Invalid operator.");
            }
        }

    }
}


