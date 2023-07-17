using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApplicationBackend.Model;
using QuizApplicationBackend.Repository.IRepository;

namespace QuizApplicationBackend.Controllers
{
    [Route("Question")]
    [ApiController]
    //[Authorize]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;
        public QuestionController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        [HttpGet("GetAllQuestions")]
        public IActionResult Get() 
        {
            var questions=_questionRepository.GetAll();
            return Ok(questions);
        }
         [HttpGet("GetAllCSharpQuestion")]
        public IActionResult GetCSharpQuestion()
        {
            var AllQuestion = _questionRepository.GetAllCSharpQuestion();
            return Ok(AllQuestion);
        }
        [HttpGet("GetAllHTMLQuestion")]
        public IActionResult GetHTMLQuestions()
        {
            var allquestions = _questionRepository.GetAllHTMLQuestion();
            return Ok(allquestions);
        }
        [HttpGet("GetAllTypeScriptQuestions")]
        public IActionResult GetAllTypeScriptQuestions()
        {
            var allQuestions= _questionRepository.GetAllTypeScriptQuestion();
            return Ok(allQuestions);
        }
        [HttpGet("QuestionById")]
        public IActionResult GetQuestionById(int id)
        {
            var question= _questionRepository.GetQuestionsById(id);
            return Ok(question);
        }
        [HttpPost("AddQuestion")]
        public IActionResult AddQuestion(QuestionTable question)
        {
            _questionRepository.CreateQuestionAsync(question);
            return Ok( question);
        }
        [HttpPut("UpdateQuestion")]
        public IActionResult UpdateQuestion(QuestionTable question)
        {
            _questionRepository.UpdateQuestion(question);
            return Ok();
        }
        
    }
}
