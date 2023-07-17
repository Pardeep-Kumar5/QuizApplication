using QuizApplicationBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplicationBackend.Repository.IRepository
{
  public  interface IQuestionRepository
    {
          Task CreateQuestionAsync (QuestionTable question);
        void UpdateQuestion(QuestionTable question);
        IEnumerable<QuestionTable> GetAllCSharpQuestion();
        IEnumerable<QuestionTable> GetAllHTMLQuestion();
        IEnumerable<QuestionTable> GetAllTypeScriptQuestion();
        QuestionTable GetQuestionsById(int id);
        IEnumerable<QuestionTable> GetAll();

    }
}
