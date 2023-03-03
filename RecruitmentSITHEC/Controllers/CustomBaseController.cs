using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentSITHEC.DTO_s;
using RecruitmentSITHEC.Entities;
using RecruitmentSITHEC.Extensions;
using RecruitmentSITHEC.Helpers.Pagination;

namespace RecruitmentSITHEC.Controllers
{
    public class CustomBaseController : ControllerBase
    {
        //private readonly ApplicationDBContext _context;
        //private readonly IMapper _mapper;

        //public CustomBaseController(ApplicationDBContext context, IMapper mapper)
        //{
        //    _context = context;
        //    _mapper = mapper;
        //}

        //protected async Task<List<TDTO>> Get<TEntidad, TDTO>() where TEntidad : class
        //{
        //    var entidades = await _context.Set<TEntidad>().ToListAsync();
        //    return _mapper.Map<List<TDTO>>(entidades);
        //}

        //protected async Task<List<TDTO>> Get<TEntidad, TDTO>(PaginationDTO paginacionDTO)
        //    where TEntidad : class
        //{
        //    var queryable = _context.Set<TEntidad>().AsQueryable(); 
        //    return await Get<TEntidad, TDTO>(paginacionDTO, queryable);
        //}
         
        //protected async Task<List<TDTO>> Get<TEntidad, TDTO>(PaginationDTO paginacionDTO, IQueryable<TEntidad> queryable)
        //    where TEntidad : class
        //{
        //    await HttpContext.PaginationOnHeader(queryable);
        //    var actores = await queryable.Paginate(paginacionDTO).ToListAsync();
        //    return _mapper.Map<List<TDTO>>(actores);
        //}
          
        //protected async Task<ActionResult<TDTO>> Get<TEntidad, TDTO>(int id) where TEntidad : class, IBaseEntity
        //{
        //    var entidad = await _context.Set<TEntidad>().FirstOrDefaultAsync(x => x.Id == id);
        //    if (entidad is null) return NotFound();
        //    return _mapper.Map<TDTO>(entidad);
        //}


    }
}
