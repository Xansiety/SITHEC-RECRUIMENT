﻿namespace RecruitmentSITHEC.Entities
{
    public class Human : IBaseEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Sexo { get; set; }
        public int Edad { get; set; }
        public decimal Altura { get; set; }
        public decimal Peso { get; set; } 
    }
}
