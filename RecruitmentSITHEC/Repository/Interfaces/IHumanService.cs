using RecruitmentSITHEC.DTOS;
using RecruitmentSITHEC.Entities;

namespace RecruitmentSITHEC.Repository.Interfaces
{
    public interface IHumanService
    {
        Task<Human> AddHuman(Human human);
        Task  DeleteHuman(Human human);
        Task<(int totalRecords, List<Human> records)> GetAllHumans(int page, int recordsPerPage);
        Task<Human> GetHumanByID(int id); 
        Task UpdateHuman(Human human);
        Task<bool> ValidateHumanExist(string name);
    }
}
