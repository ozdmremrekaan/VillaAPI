using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Principal;
using VillaAPI.Data;
using VillaAPI.Models;
using VillaAPI.Models.Dto.Villa;
using VillaAPI.Repository.IRepository;

namespace VillaAPI.Controllers
{
    [Route("VillaApi")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        protected ApiResponse _response;
        private readonly IVillaRepository _context;
        private readonly IMapper _mapper;
        public VillaController(IVillaRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            this._response = new();
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> Get()
        {
            var villaList = await _context.GetAllAsync();
            _response.Result = _mapper.Map<List<VillaDto>>(villaList);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse>> Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = await _context.GetAsync(x => x.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            _response.Result = _mapper.Map<VillaDto>(villa);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Post([FromBody]VillaCreateDto villaDto)
        {
            
            if(await _context.GetAsync(x=> x.Name.ToLower() == villaDto.Name.ToLower())!=null)
                {
                return BadRequest();
            }
            var villa = _mapper.Map<Villa>(villaDto);
            await _context.CreateAsync(villa);
            _response.Result = _mapper.Map<VillaDto>(villa);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse>> Update([FromBody]VillaUpdateDto villaUpdateDto,int id)
        {
            if(id != villaUpdateDto.Id || villaUpdateDto == null)
            {
                return BadRequest();
            }
            var villa = _mapper.Map<Villa>(villaUpdateDto);
            await _context.UpdateAsync(villa);

            _response.Result = _mapper.Map<VillaDto>(villa);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse>> Delete(int id)
        {
            var villa = await _context.GetAsync(x=> x.Id == id);

            if(villa == null)
            {
                return NotFound();
            }

            await _context.RemoveAsync(villa);

            _response.Result = _mapper.Map<VillaDto>(villa);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);


        }
    }
}
