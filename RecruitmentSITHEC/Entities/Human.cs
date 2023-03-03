namespace RecruitmentSITHEC.Entities
{
    public class Human : BaseEntity
    {
        public string Nombre { get; set; }
        public char Sexo { get; set; }
        public int Edad { get; set; }
        public decimal Altura { get; set; }
        public decimal Peso { get; set; }
    }
}
