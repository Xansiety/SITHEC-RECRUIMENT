using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecruitmentSITHEC.DTO_s;
using RecruitmentSITHEC.DTOs.Human;
using RecruitmentSITHEC.DTOS;
using RecruitmentSITHEC.Entities;
using RecruitmentSITHEC.Helpers.Pagination;
using RecruitmentSITHEC.Repository.Interfaces;

namespace RecruitmentSITHEC.Controllers
{
    [Route("api/humano")]
    [ApiController]
    public class HumanController : ControllerBase
    {
        private readonly IHumanService _humanService;
        private readonly IMapper _mapper;

        public HumanController(IHumanService humanService, IMapper mapper)
        {
            _humanService = humanService;
            _mapper = mapper;
        }
         
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Human>>> Get([FromQuery] PaginationDTO pagination)
        {
            var humans = await _humanService.GetHumans(pagination);

            var humanList = _mapper.Map<List<HumanListDTO>>(humans);

            var totalRecords = humanList.Count();
            Response.Headers.Add("x-total-records", totalRecords.ToString());
            var response = new Paginator<HumanListDTO>(humanList, totalRecords, pagination.Page, pagination.RecordsPerPage);
            return Ok(response);
        }

    }
}
