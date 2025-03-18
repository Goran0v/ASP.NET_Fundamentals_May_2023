using Library.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BookController : BaseController
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public async Task<IActionResult> All()
        {
            var model = await bookService.GetAllBooksAsync();

            return View(model);
        }

        public async Task<IActionResult> Mine()
        {
            var model = await bookService.GetMyBooksAsync(GetUserId());

            return View(model);
        }

        public async Task<IActionResult> AddToCollection()
        {
            var book = await bookService.GetMyBooksAsync(GetUserId());
        }

        //[AllowAnonymous]
        //public IActionResult Add()
        //{
        //    if (User?.Identity?.IsAuthenticated ?? false)
        //    {
        //        return RedirectToAction("All", "Book");
        //    }

        //    return View();
        //}
    }
}
