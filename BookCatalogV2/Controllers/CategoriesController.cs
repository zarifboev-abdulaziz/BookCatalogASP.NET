using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookCatalogv2.Data;
using BookCatalogv2.Models;
using BookCatalogv2.Repositories;
using BookCatalogv2.Models;
using BookCatalogv2.Repositories;
using Microsoft.AspNetCore.Cors;

namespace BookCatalogv2.Controllers
{
    [EnableCors("AllowAngularApp")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly IRepository<Category> _categoryRepository;
        public CategoriesController(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }





        // GET: api/Categories
        [HttpGet]
        public async Task<IEnumerable<Category>> GetCategory()
        {
            return await _categoryRepository.GetAllAsync();
        }




        // GET: api/Categories/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var resultedCategory = await _categoryRepository.GetByIDAsync(id);
            return resultedCategory == null ? NotFound() : Ok(resultedCategory);
        }





        // PUT: api/Categories/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            //if(id!=items.ID) return BadRequest();
            await _categoryRepository.UpdateAsync(category);
            return NoContent();
        }





        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            await _categoryRepository.AddAsync(category);
            return Ok(category);
            //return CreatedAtAction(nameof(GetByID), new { id = items.ID }, items);
        }





        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryRepository.DeleteAsync(id);
            return NoContent();
        }

    }
}
