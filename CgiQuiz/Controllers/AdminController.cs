using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CgiQuiz.Models;
using Microsoft.AspNetCore.Http;

namespace CgiQuiz.Controllers
{
    public class AdminController : Controller
    {
        private OurDbContext _context;
        public AdminController(OurDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.questions.ToList());
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Question question)
        {
            if (ModelState.IsValid)
            {
                _context.questions.Add(question);
                _context.SaveChanges();

                ModelState.Clear();
                ViewBag.Message = question.QuestionText + " is successfully registered";
            }
            return View();
        }

        public ActionResult Welcome()
        {
            if (HttpContext.Session.GetString("UserID") != null)
            {
                return View(_context.questions.ToList());
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
