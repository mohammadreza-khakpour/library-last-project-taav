using Library.Services.BorrowedBooks;
using Library.Services.BorrowedBooks.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.RestApi.Controllers
{
    [ApiController]
    [Route("api/borrowed-books")]
    public class BorrowedBooksController : Controller
    {
        private BorrowedBookService _service;
        public BorrowedBooksController(BorrowedBookService service)
        {
            _service = service;
        }

        [HttpPost]
        public void Add([Required][FromBody] AddBorrowedBookDto dto)
        {
            _service.Add(dto);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
