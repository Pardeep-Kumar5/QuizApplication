using Microsoft.AspNetCore.Mvc;
using QuizApplicationBackend.Data;
using QuizApplicationBackend.Model;
using System;
using System.Linq;
using System.Net.Http;

namespace QuizApplicationBackend.Controllers
{
    [Route("Quiz")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public QuizController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("GetQuiz")]
        public IActionResult GetQuestions(int categoryId)
        {
            var ons = _context.questionTables.Where(s=>s.categoryTable.Id==categoryId).
                Select(x => new
            {
                QuestionId = x.Question_Id,
                QuestionText = x.QuestionText,
                Option1 = x.Option1,
                Option2 = x.Option2,
                Option3 = x.Option3,
                Option4 = x.Option4,
            }).
            OrderBy(y => Guid.NewGuid())
            .Take(10)
            .ToArray();

            var Update = ons.AsEnumerable()
                .Select(x => new
                {
                    QuestionId = x.QuestionId,
                    QuestionText = x.QuestionText,
                    Options = new string[] { x.Option1, x.Option2, x.Option3, x.Option4 },

                }).ToList();
            return Ok(Update);
        }
        [HttpPost("Answer")]
        public IActionResult GetAnswer(int[] queId)
        {
            var result=_context.questionTables
                .AsEnumerable()
                .Where(y=>queId.Contains(y.Question_Id))
                .OrderBy(x => { return Array.IndexOf(queId,x.Question_Id); })
                .Select(z=>z.Answer)
                .ToList();
            return Ok(result);
        }
    }
}
