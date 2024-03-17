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
    public class BooksController : ControllerBase
    {


        private readonly IRepository<Book> _bookRepository;
        public BooksController(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }




        // GET: api/Books
        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepository.GetAllAsync();
        }






        // GET: api/Books/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var resultedBook = await _bookRepository.GetByIDAsync(id);
            return resultedBook == null ? NotFound() : Ok(resultedBook);
        }






        // PUT: api/Books/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            //if(id!=items.ID) return BadRequest();
            await _bookRepository.UpdateAsync(book);
            return NoContent();
        }





        // POST: api/Books
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            await _bookRepository.AddAsync(book);
            return Ok(book);
            //return CreatedAtAction(nameof(GetByID), new { id = items.ID }, items);
        }






        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
