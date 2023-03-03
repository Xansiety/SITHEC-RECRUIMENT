using RecruitmentSITHEC.DTO_s;
using RecruitmentSITHEC.Entities;

namespace RecruitmentSITHEC.Repository.Interfaces
{
    public interface IHumanService
    {
        void AddHuman(Human human);
        void DeleteHuman(int id);
        void Dispose();
        Human GetHuman(int id); 
        Task<List<Human>> GetHumans(PaginationDTO pagination);
        void UpdateHuman(Human human);
    }
}
