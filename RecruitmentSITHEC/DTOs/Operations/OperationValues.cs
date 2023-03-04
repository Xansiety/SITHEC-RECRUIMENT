using RecruitmentSITHEC.Helpers.Constantes;
using System.ComponentModel.DataAnnotations;

namespace RecruitmentSITHEC.DTOs.Operations
{
    public class OperationValues
    {
        [Required(ErrorMessage = "The field {0} is required.")]
        public double a { get; set; } = 5;  

        [Required(ErrorMessage = "The field {0} is required.")]
        public double b { get; set; } = 2;

        [Required(ErrorMessage = "The field {0} is required.")]
        public string Operator { get; set; } = Operadores.addition;
    }
}
