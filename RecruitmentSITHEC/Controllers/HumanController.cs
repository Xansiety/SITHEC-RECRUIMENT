using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecruitmentSITHEC.DTOs.Human;
using RecruitmentSITHEC.DTOS;
using RecruitmentSITHEC.Entities;
using RecruitmentSITHEC.Helpers.Abstracts;
using RecruitmentSITHEC.Helpers.Errors;
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


        [HttpGet("mock-humans")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetMockHumans()
        {
            MockData mockData = new MockData();
            return Ok(mockData.HumansList());
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<Human>>> Get([FromQuery] PaginationDTO pagination)
        {
            var humans = await _humanService.GetHumans(pagination);
            var humanList = _mapper.Map<List<HumanListDTO>>(humans);
            var totalRecords = humanList.Count();
            Response.Headers.Add("x-total-records", totalRecords.ToString());
            var response = new Paginator<HumanListDTO>(humanList, totalRecords, pagination.Page, pagination.RecordsPerPage);
            return Ok(response);
        }


        [HttpGet("GetHumanById/{id:int}", Name = "GetHumanById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var human = await _humanService.GetHumanByID(id);
            if (human is null) return NotFound(new ResponseAPI(404, $"Human with Id {id} not found"));
            if (human.Id != id) return BadRequest(new ResponseAPI(400, "Invalid petition"));
            return Ok(human);
        }


        [HttpPost("CreateHuman")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] HumanCreateDTO model)
        {
            var human = await _humanService.ValidateHumanExist(model.Nombre);
            if (human) return BadRequest(new ResponseAPI(400, $"The human with name {model.Nombre}, already in the database"));

            var humanToSave = _mapper.Map<Human>(model);
            var humanCreated = await _humanService.AddHuman(humanToSave);
            return CreatedAtRoute("GetHumanById", new { id = humanCreated.Id }, humanToSave);
        }


        [HttpPut("UpdateHuman/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] HumanCreateDTO model, [FromRoute] int id)
        {
            var humanDB = await _humanService.GetHumanByID(id);
            if (humanDB is null) return NotFound(new ResponseAPI(404, $"Human with Id {id} not found"));
            if (humanDB.Id != id) return BadRequest(new ResponseAPI(400, "Invalid petition"));
            humanDB = _mapper.Map(model, humanDB);
            await _humanService.UpdateHuman(humanDB);
            return NoContent();
        }


        [HttpDelete("DeteleHuman/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var humanDB = await _humanService.GetHumanByID(id);
            if (humanDB is null) return NotFound(new ResponseAPI(404, $"Human with Id {id} not found"));
            await _humanService.DeleteHuman(humanDB);
            return NoContent();
        }
         

    }
}
