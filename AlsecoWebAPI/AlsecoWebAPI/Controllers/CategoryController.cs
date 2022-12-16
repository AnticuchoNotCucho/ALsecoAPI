using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlsecoWebAPI.Interfaces;
using AlsecoWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlsecoWebAPI.Controllers
{
    [ApiController]
    [Route("Categories/")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryRepository.GetCategories();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryRepository.GetCategory(id);
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] Category category)
        {
            var result = await _categoryRepository.AddCategory(category);
            if (result)
            {
                return Ok("agredada categoria: " + category.Name);
            }
            return BadRequest("No se pudo agregar");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] Category category)
        {
            var result = await _categoryRepository.UpdateCategory(category);
            if (result)
            {
                return Ok(category);
            }
            return BadRequest("Failed to update category");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryRepository.DeleteCategory(id);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Failed to delete category");
        }
    }
}
