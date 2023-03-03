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

        public async Task<List<Human>> GetHumans(PaginationDTO pagination)
        { 
            return await _context.Humans.Skip((pagination.Page - 1) * pagination.RecordsPerPage)
                .Take(pagination.RecordsPerPage).ToListAsync(); 
        }

        public void AddHuman(Human human)
        {
            _context.Humans.Add(human);
            _context.SaveChanges();
        }

        public Human GetHuman(int id)
        {
            return _context.Humans.Find(id);
        }

        public void UpdateHuman(Human human)
        {
            _context.Humans.Update(human);
            _context.SaveChanges();
        }

        public void DeleteHuman(int id)
        {
            var human = _context.Humans.Find(id);
            _context.Humans.Remove(human);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
