using AppCore.DTOs;
using AppCore.Interfaces;
using AutoMapper;
using deliveryAppCore.Entities;
using deliveryAppCore.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace AppWebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class POSController : Controller
    {
        private readonly IPO _IPO;
        private readonly IMapper _mapper;
        private IConfiguration _config;
        public POSController(IPO IPO, IConfiguration config, IMapper mapper)
        {
            _IPO = IPO;
            _config = config;
            _mapper = mapper;

        }

        [Authorize]
        [HttpPost("CreatePOS")]
        public async Task<IActionResult> CreatePOS(PoDto PoDto)
        {
            var pos = _mapper.Map<Po>(PoDto);
            var dataAsync = await _IPO.InsertPOS(pos);
            var response = dataAsync ? ApiResponse<Boolean>.Success(dataAsync) : ApiResponse<Boolean>.Fail(_config["msgs:ErrorRequest"].ToString());
            return Ok(response);
        }


    }
}
