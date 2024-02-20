using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
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
        [Authorize(Roles = "admin")]
        
        public async Task<ActionResult<ApiResponse>> Get(int pagesize = 0, int pagenumber = 1)
        {
            var villaList = await _context.GetAllAsync(pagesize:pagesize, pagenumber:pagenumber);
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
                _response.IsSuccess = false;
                return NotFound();
            }
            _response.Result = _mapper.Map<VillaDto>(villa);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ApiResponse>> Post([FromBody]VillaCreateDto villaDto)
        {
            
            if(await _context.GetAsync(x=> x.Name.ToLower() == villaDto.Name.ToLower())!=null)
            {
                _response.IsSuccess = false;
                return BadRequest();
            }
            var villa = _mapper.Map<Villa>(villaDto);
            await _context.CreateAsync(villa);
            _response.Result = _mapper.Map<VillaDto>(villa);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);

        }
        [HttpPut("{id}")]
        [Authorize]
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
        [Authorize]
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
