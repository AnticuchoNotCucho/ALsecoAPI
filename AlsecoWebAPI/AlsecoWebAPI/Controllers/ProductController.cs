using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlsecoWebAPI.Interfaces;
using AlsecoWebAPI.Models;
using AlsecoWebAPI.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlsecoWebAPI.Controllers
{
    [ApiController]
    [Route("Products/")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductController (IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _productRepository.GetAllProducts());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            return Ok(await _productRepository.GetProductById(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (product == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _productRepository.AddProduct(product);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            var productToUpdate = await _productRepository.UpdateProduct(product);
            if (productToUpdate == false)
            {
                return NotFound("Producto no encontrado");
            }
            return Ok("Producto actualizado");;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var productDeleted = await _productRepository.DeleteProduct(id);
            if (productDeleted == false)
            {
                return NotFound("Producto no encontrado");
            }
            return Ok("Producto eliminado");
        }
    }
}
