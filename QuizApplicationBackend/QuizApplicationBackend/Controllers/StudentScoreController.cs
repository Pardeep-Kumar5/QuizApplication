using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApplicationBackend.Data;
using QuizApplicationBackend.MappingProfile.DTOs;
using QuizApplicationBackend.Model;
using System.Linq;

namespace QuizApplicationBackend.Controllers
{
    [Route("Score")]
    [ApiController]
    public class StudentScoreController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public StudentScoreController(ApplicationDbContext context)
        {
            _context=context;
        }
        [HttpGet("CSharpScore")]
        public IActionResult GetCSharpScore()
        {
            var data = _context.StudentScoreTable
                .Include(s => s.registerTable)
                .Include(s => s.CategoryTable)
                .Select(s => new StudentScoreDto
                {
                    ScoreID = s.ScoreID,
                    Score = s.Score,
                    TimeSpent = s.TimeSpent,
                    registerTable = s.registerTable,
                    RegisterId = s.RegisterId,
                    CategoryId = s.CategoryId,
                    CategoryTable = s.CategoryTable,
                }).Where(s => s.CategoryId == 1);
            return Ok(data);
        }
        [HttpGet("GetHtmlScore")]
        public IActionResult GetHtml()
        {
            var data=_context.StudentScoreTable
                .Include(s=>s.registerTable)
                .Include(s=>s.CategoryTable)
                .Select(s=> new StudentScoreDto
                {
                    ScoreID = s.ScoreID,
                    Score = s.Score,
                    TimeSpent = s.TimeSpent,
                    registerTable = s.registerTable,
                    RegisterId = s.RegisterId,
                    CategoryId = s.CategoryId,
                    CategoryTable = s.CategoryTable,
                }).Where(s=>s.CategoryId == 2);
            return Ok(data);
        }
        [HttpGet("GetAngularScore")]
        public IActionResult GetAngular()
        {
            var data = _context.StudentScoreTable
                 .Include(s => s.registerTable)
                 .Include(s => s.CategoryTable)
                 .Select(s => new StudentScoreDto
                 {
                     ScoreID = s.ScoreID,
                     Score = s.Score,
                     TimeSpent = s.TimeSpent,
                     registerTable = s.registerTable,
                     RegisterId = s.RegisterId,
                     CategoryId = s.CategoryId,
                     CategoryTable = s.CategoryTable,
                 }).Where(s => s.CategoryId == 3);
            return Ok(data);
        }

        [HttpPost("StudentScore")]
        public IActionResult AddScore(ScoreTable Score)
        {
            _context.StudentScoreTable.Add(Score);
            _context.SaveChanges();
            return Ok( Score);
        }
        [HttpGet("GetScore")]
        public IActionResult GetAllScore()
        {
            var data = _context.StudentScoreTable
                .Include(s => s.registerTable)
                .Include(s=>s.CategoryTable)
                .Select(s => new StudentScoreDto
                {
                    ScoreID = s.ScoreID,
                    Score = s.Score,
                    TimeSpent = s.TimeSpent,
                    registerTable = s.registerTable,
                    RegisterId = s.RegisterId,
                    CategoryId=s.CategoryId,
                    CategoryTable=s.CategoryTable,
                }).ToList();
            return Ok( data );
        }
        [HttpGet("RegisterById")]
        public IActionResult GetScoreByRegisterId(int registerId)
        {
            var data = _context.StudentScoreTable
                .Include(s => s.registerTable)
                .Include(s => s.CategoryTable)
                .Select(s => new StudentScoreDto
                {
                    ScoreID = registerId,
                    Score = s.Score,
                    TimeSpent = s.TimeSpent,
                    registerTable = s.registerTable,
                    RegisterId = s.RegisterId,
                   CategoryId=s.CategoryId,
                   CategoryTable=s.CategoryTable,
                }).Where(s => s.RegisterId == registerId).ToList();
            return Ok(data);
        }
    }
}
