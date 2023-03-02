using Microsoft.AspNetCore.Mvc;
using Mission09_clhwang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_clhwang.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;
        public HomeController (IBookstoreRepository temp)
        {
            repo = temp;
        }
        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 5;

            var blah = repo.Books
                .OrderBy(b => b.Title)
                .Skip(pageNum * pageSize)
                .Take(pageSize);
            return View(blah);
        }
    }
}
