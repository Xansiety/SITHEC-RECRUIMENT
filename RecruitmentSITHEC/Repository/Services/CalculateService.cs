using RecruitmentSITHEC.Helpers.Abstracts;
using RecruitmentSITHEC.Repository.Interfaces;

namespace RecruitmentSITHEC.Repository.Services
{
    public class CalculateService : ICalculateService
    {
        /// <summary>
        /// Calculate the result of operation
        /// </summary>
        /// <param name="operation">Abstract class to make operations</param>
        /// <returns></returns>
        public double CalculateResult(Operation operation)
        {
            double resultado = operation.CalculateValue();
            return resultado;
        }
    }
}
