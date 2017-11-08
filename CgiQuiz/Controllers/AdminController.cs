using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CgiQuiz.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

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

     //GET: Admin/Edit/id
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var question = await _context.questions.AsNoTracking().SingleOrDefaultAsync(q => q.QuestionID == id);
            if(question == null)
            {
                return NotFound();
            }
            return View(question);
        }

        //POST: Admin/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditQues(int QuestionID)
        {
            if (QuestionID == null)
            { return NotFound(); }

            var questionUpdate = await _context.questions.SingleOrDefaultAsync(q => q.QuestionID == QuestionID);

            if(await TryUpdateModelAsync<Question>(questionUpdate, "", q=>q.QuestionText, q=>q.AnswerA, q=>q.AnswerB, q => q.AnswerC, q => q.AnswerD, q=>q.CorrectAnswer))
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. try again, and if the problem persists, see your system administrator");
                }
                return RedirectToAction("Welcome");
            }
            return View(questionUpdate);

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
            return RedirectToAction("Index", "Home");
        }
    }
}
