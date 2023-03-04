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

        /// <summary>
        /// Validate if human exist by name, in the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<bool> ValidateHumanExist(string name)
        {
            return await _context.Humans.AnyAsync(x => x.Nombre == name);
        }


        /// <summary>
        ///  Get all humans from database
        /// </summary>
        /// <param name="pagination"> Parameters for pagination result </param>
        /// <returns></returns>
        public async Task<List<Human>> GetHumans(PaginationDTO pagination)
        {
            return await _context.Humans.Skip((pagination.Page - 1) * pagination.RecordsPerPage)
                .Take(pagination.RecordsPerPage).ToListAsync();
        }


        /// <summary>
        /// Add new human to database
        /// </summary>
        /// <param name="human"> Type of new human </param>
        /// <returns></returns>
        public async Task<Human> AddHuman(Human human)
        {
            _context.Humans.Add(human);
            await _context.SaveChangesAsync();
            return human;
        }


        /// <summary>
        /// Get a human by id from the database
        /// </summary>
        /// <param name="id">Id of search</param>
        /// <returns></returns>
        public async Task<Human> GetHumanByID(int id)
        {
            return await _context.Humans.FirstOrDefaultAsync(x => x.Id == id);
        }


        /// <summary>
        /// Update info of human in database
        /// </summary>
        /// <param name="human"> Type of new values to human </param>
        /// <returns></returns>
        public async Task UpdateHuman(Human human)
        {
            _context.Humans.Update(human);
            await _context.SaveChangesAsync();
        }


        /// <summary>
        /// Delete human from database
        /// </summary>
        /// <param name="human"> Type to delete </param>
        /// <returns></returns>

        public async Task DeleteHuman(Human human)
        {
            _context.Humans.Remove(human);
            await _context.SaveChangesAsync();
        }


    }
}
