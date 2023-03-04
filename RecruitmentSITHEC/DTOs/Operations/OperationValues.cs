using System.ComponentModel.DataAnnotations;

namespace RecruitmentSITHEC.DTOs.Operations
{
    public class OperationValues
    {
        [Required(ErrorMessage = "The field {0} is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Please add a valid number")]
        public double a { get; set; } 

        [Required(ErrorMessage = "The field {0} is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Please add a valid number")]
        public double b { get; set; } 
         
        [Required(ErrorMessage = "The field {0} is required.")]
        public string Operator { get; set; }  
    }
}
