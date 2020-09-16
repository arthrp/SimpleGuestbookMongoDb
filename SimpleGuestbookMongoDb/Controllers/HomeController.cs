using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleGuestbookMongoDb.Dto;
using SimpleGuestbookMongoDb.Models;

namespace SimpleGuestbookMongoDb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GuestbookRepository _postsRepository;

        public HomeController(ILogger<HomeController> logger, GuestbookRepository postsRepository)
        {
            _logger = logger;
            _postsRepository = postsRepository;
        }

        public IActionResult Index()
        {
            var posts = _postsRepository.GetAll();
            return View(new GuestbookViewModel() { Posts = posts });
        }

        [HttpPost("add")]
        public IActionResult Add(GuestbookPostDto post)
        {
            _postsRepository.Add(post);

            var posts = _postsRepository.GetAll().ToList();
            return View("Index", new GuestbookViewModel() { Posts = posts });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
