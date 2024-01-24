using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using VillaAPI.Models.Dto.Villa;
using VillaAPI.Models;
using VillaAPI.Repository.IRepository;
using VillaAPI.Models.Dto.VillaNumber;
using Microsoft.AspNetCore.Http.HttpResults;

namespace VillaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VillaNumberController : ControllerBase
    {
        protected ApiResponse _response;
        private readonly IVillaNumberRepository _context;
        private readonly IVillaRepository _ncontext;
        private readonly IMapper _mapper;
        public VillaNumberController(IVillaNumberRepository context, IMapper mapper, IVillaRepository ncontext)
        {
            _context = context;
            _mapper = mapper;
            _ncontext = ncontext;
            this._response = new();
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> Get()
        {
            var villaList = await _context.GetAllAsync(includeProperties: "Villa");
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
            var villa = await _context.GetAsync(x => x.VillaNo == id, includeProperties: "Villa");
            if (villa == null)
            {
                return NotFound();
            }
            _response.Result = _mapper.Map<VillaNumberDto>(villa);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Post([FromBody] VillaNumberCreateDto createDto)
        {
            try
            {

                if (await _context.GetAsync(u => u.VillaNo == createDto.VillaNo) != null)
                {
                    ModelState.AddModelError("ErrorMessages", "Villa Number already Exists!");
                    return BadRequest(ModelState);
                }
                if (await _ncontext.GetAsync(u => u.Id == createDto.VillaId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Villa ID is Invalid!");
                    return BadRequest(ModelState);
                }
                if (createDto == null)
                {
                    return BadRequest(createDto);
                }

                VillaNumber villaNumber = _mapper.Map<VillaNumber>(createDto);


                await _context.CreateAsync(villaNumber);
                _response.Result = _mapper.Map<VillaNumberDto>(villaNumber);
                _response.StatusCode = HttpStatusCode.Created;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPut("id")]
        public async Task<ActionResult<ApiResponse>> Update([FromBody] VillaNumberUpdateDto villaNumberUpdateDto, int id)
        {
            try
            {
                if (villaNumberUpdateDto == null || id != villaNumberUpdateDto.VillaNo)
                {
                    return BadRequest();
                }
                if (await _ncontext.GetAsync(u => u.Id == villaNumberUpdateDto.VillaId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Villa ID is Invalid!");
                    return BadRequest(ModelState);
                }
                VillaNumber model = _mapper.Map<VillaNumber>(villaNumberUpdateDto);

                await _context.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
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
