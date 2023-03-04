using System.ComponentModel.DataAnnotations;

namespace RecruitmentSITHEC.DTOs.Human
{
    public class HumanCreateDTO
    {
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(maximumLength: 180, ErrorMessage = "The field {0}, must not contain more than {1} characters.")]
        public String Nombre { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(1, 3, ErrorMessage = "Please add a valid {0}, between a range of {1} and {2}")]
        public int Sexo { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [Range(5, 99, ErrorMessage = "Please add a valid {0}, between a range of {1} and {2}")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        public decimal Altura { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        public decimal Peso { get; set; }
    }
}
