using Library.Services.Books.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.RestApi.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : Controller
    {
        private BookService _service;
        public BooksController(BookService service)
        {
            _service = service;
        }

        [HttpPost]
        public int Add([Required][FromBody] AddBookDto dto)
        {
            return _service.Add(dto);
        }
        [HttpPut("{id}")]
        public int Update(int id, [FromBody] UpdateBookDto dto)
        {
            return _service.Update(id, dto);
        }
    }
}
