using Microsoft.AspNetCore.Mvc; 
using Mission09_clhwang.Models;
using Mission09_clhwang.Models.ViewModels;
using System.Linq;

namespace Mission09_clhwang.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;
        public HomeController (IBookstoreRepository temp)
        {
            repo = temp;
        }
        public IActionResult Index(string bookstoreType, int pageNum = 1)
        {
            //Settig how many books per page
            int pageSize = 10;

            //How the books are organized on the page
            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == bookstoreType || bookstoreType == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = (bookstoreType == null
                        ? repo.Books.Count()
                        : repo.Books.Where(x => x.Category == bookstoreType).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
    }
}
