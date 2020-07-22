using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;

namespace WebApp.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;
        private string UserId { get; set; }

        public SearchController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            UserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        //Get
        public IActionResult ToSearch()
        {
            var applicationDbContext = _context.Notes.Where(x => x.UserId == UserId);
            return View(applicationDbContext.ToList());
        }

        //Post
        [HttpPost]
        public IActionResult ToSearch(string titleText)
        {
            var data = _context.Notes.Where(x => x.Title.Contains(titleText));
            return View(data);
        }

    }
}
