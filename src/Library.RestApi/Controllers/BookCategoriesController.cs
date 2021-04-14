using Library.Services.BookCategories;
using Library.Services.BookCategories.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.RestApi.Controllers
{
    [ApiController]
    [Route("api/book-categories")]
    public class BookCategoriesController : Controller
    {
        private BookCategoryService _service;
        public BookCategoriesController(BookCategoryService service)
        {
            _service = service;
        }

        [HttpPost]
        public int Add([Required][FromBody] AddBookCategoryDto dto)
        {
            return _service.Add(dto);
        }
    }
}