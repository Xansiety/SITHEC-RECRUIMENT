using Microsoft.EntityFrameworkCore;
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
        /// <param name="page"> Page number </param>
        /// <param name="recordsPerPage"> Total record per page </param>
        /// <returns></returns>
        public async Task<(int totalRecords, List<Human> records)> GetAllHumans(int page, int recordsPerPage)
        {
            var queryable = _context.Humans.AsQueryable();
            var totalRecords = await queryable.CountAsync();
            var records = await queryable.Skip((page - 1) * recordsPerPage)
                .Take(recordsPerPage).ToListAsync();
            return (totalRecords, records);
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
