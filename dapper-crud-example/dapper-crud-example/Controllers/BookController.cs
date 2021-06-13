using dapper_crud_example.Models;
using dapper_crud_example.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dapper_crud_example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(bookRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return Ok(bookRepository.GetById(int.Parse(id)));
        } 

        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            return Ok(bookRepository.Add(book));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook([FromBody] Book book, string id)
        {
            book.BookId = int.Parse(id);
            bookRepository.Update(book);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(string id)
        {
            bookRepository.Delete(int.Parse(id));
            return Ok();
        }
    }
}
