using Microsoft.EntityFrameworkCore;
using RecruitmentSITHEC.DTOS;
using RecruitmentSITHEC.Entities;
using RecruitmentSITHEC.Repository.Interfaces;

namespace RecruitmentSITHEC.Repository.Services
{
    public class HumanService : IHumanService
    {
        private readonly ApplicationDBContext _context;
        public HumanService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool> ValidateHumanExist(string name)
        {
            return await _context.Humans.AnyAsync(x => x.Nombre == name);
        }


        public async Task<List<Human>> GetHumans(PaginationDTO pagination)
        {
            return await _context.Humans.Skip((pagination.Page - 1) * pagination.RecordsPerPage)
                .Take(pagination.RecordsPerPage).ToListAsync();
        }

        public async Task<Human> AddHuman(Human human)
        {
            _context.Humans.Add(human);
            await _context.SaveChangesAsync();
            return human;
        }

        public async Task<Human> GetHumanByID(int id)
        {
            return await _context.Humans.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateHuman(Human human)
        {
            _context.Humans.Update(human);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHuman(Human human)
        {
            _context.Humans.Remove(human);
            await _context.SaveChangesAsync();
        }
   

    }
}
