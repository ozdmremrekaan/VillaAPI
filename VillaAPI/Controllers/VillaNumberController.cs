using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using VillaAPI.Models.Dto.Villa;
using VillaAPI.Models;
using VillaAPI.Repository.IRepository;
using VillaAPI.Models.Dto.VillaNumber;

namespace VillaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaNumberController : ControllerBase
    {
        protected ApiResponse _response;
        private readonly IVillaNumberRepository _context;
        private readonly IMapper _mapper;
        public VillaNumberController(IVillaNumberRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            this._response = new();
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> Get()
        {
            var villaList = await _context.GetAllAsync();
            _response.Result = _mapper.Map<List<VillaNumberDto>>(villaList);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpGet("id")]
        public async Task<ActionResult<ApiResponse>> Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = await _context.GetAsync(x => x.VillaNo == id);
            if (villa == null)
            {
                return NotFound();
            }
            _response.Result = _mapper.Map<VillaNumberDto>(villa);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Post([FromBody] VillaNumberCreateDto villaNumberDto)
        {

           
            var villa = _mapper.Map<VillaNumber>(villaNumberDto);
            await _context.CreateAsync(villa);
            _response.Result = _mapper.Map<VillaNumberDto>(villa);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);

        }
        [HttpPut("id")]
        public async Task<ActionResult<ApiResponse>> Update([FromBody] VillaNumberUpdateDto villaNumberUpdateDto, int id)
        {
            if (id != villaNumberUpdateDto.VillaNo || villaNumberUpdateDto == null)
            {
                return BadRequest();
            }
            var villa = _mapper.Map<VillaNumber>(villaNumberUpdateDto);
            await _context.UpdateAsync(villa);

            _response.Result = _mapper.Map<VillaNumberDto>(villa);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);

        }
        [HttpDelete("id")]
        public async Task<ActionResult<ApiResponse>> Delete(int id)
        {
            var villa = await _context.GetAsync(x => x.VillaNo == id);

            if (villa == null)
            {
                return NotFound();
            }

            await _context.RemoveAsync(villa);

            _response.Result = _mapper.Map<VillaNumberDto>(villa);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);


        }
    }
}
