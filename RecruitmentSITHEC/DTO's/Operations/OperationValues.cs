using System.ComponentModel.DataAnnotations;

namespace RecruitmentSITHEC.DTO_s.Operations
{
    public class OperationValues
    {
        [Required(ErrorMessage = "The field {0} is required.") ]
        public int a { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        public int b { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        public int c { get; set; }
    }
}
