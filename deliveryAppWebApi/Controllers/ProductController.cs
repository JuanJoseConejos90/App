using AutoMapper;
using deliveryAppCore.DTOs;
using deliveryAppCore.Entities;
using deliveryAppCore.Interfaces;
using deliveryAppCore.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _IProduct;
        private readonly IMapper _mapper;
        private IConfiguration _config;
        public ProductController(IProduct IProduct,IConfiguration config,IMapper mapper)
        {
            _IProduct = IProduct;
            _config = config;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dataAsync = await _IProduct.getAllProducts();
            var response = ApiResponse<IEnumerable<Product>>.Success(dataAsync);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dataAsync = await _IProduct.getProduct(id);
            var response = ApiResponse<Product>.Success(dataAsync);
            return Ok(response);
        }

        [Authorize]
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(ProductDto ProductDto)
        {
            var product = _mapper.Map<Product>(ProductDto);
            var dataAsync = await _IProduct.InsertProduct(product);
            var response = dataAsync ? ApiResponse<Boolean>.Success(dataAsync) : ApiResponse<Boolean>.Fail(_config["msgs:ErrorRequest"].ToString());
            return Ok(response);
        }

        [Authorize]
        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(ProductDto ProductDto)
        {
            var product = _mapper.Map<Product>(ProductDto);
            var dataAsync = await _IProduct.UpdatetProduct(product);
            var response = dataAsync ? ApiResponse<Boolean>.Success(dataAsync) : ApiResponse<Boolean>.Fail(_config["msgs:ErrorRequest"].ToString());
            return Ok(response);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dataAsync = await _IProduct.DeletetProduct(id);
            var response = dataAsync ? ApiResponse<Boolean>.Success(dataAsync) : ApiResponse<Boolean>.Fail(_config["msgs:ErrorRequest"].ToString());
            return Ok(response);
        }



    }
}
