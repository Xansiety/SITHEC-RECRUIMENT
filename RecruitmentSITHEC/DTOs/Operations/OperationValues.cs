using System.ComponentModel.DataAnnotations;

namespace RecruitmentSITHEC.DTOs.Operations
{
    public class OperationValues
    {
        [Required(ErrorMessage = "The field {0} is required.") ]
        public double a { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        public double b { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        public double c { get; set; }
    }
}
