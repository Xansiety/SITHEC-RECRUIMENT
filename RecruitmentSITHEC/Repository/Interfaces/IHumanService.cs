using RecruitmentSITHEC.DTOS;
using RecruitmentSITHEC.Entities;

namespace RecruitmentSITHEC.Repository.Interfaces
{
    public interface IHumanService
    {
        Task<Human> AddHuman(Human human);
        Task  DeleteHuman(Human human);
        Task<Human> GetHumanByID(int id);
        Task<List<Human>> GetHumans(PaginationDTO pagination); 
        Task UpdateHuman(Human human);
        Task<bool> ValidateHumanExist(string name);
    }
}
