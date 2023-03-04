using System.ComponentModel.DataAnnotations;

namespace RecruitmentSITHEC.DTOs.Human
{
    public class HumanPatchDTO
    {
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(maximumLength: 180, ErrorMessage = "The field {0}, must not contain more than {1} characters.")]
        public String Nombre { get; set; }
    }
}
