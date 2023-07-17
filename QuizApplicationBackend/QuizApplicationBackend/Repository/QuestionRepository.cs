using Microsoft.AspNetCore.Mvc;
using QuizApplicationBackend.Data;
using QuizApplicationBackend.Model;
using QuizApplicationBackend.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplicationBackend.Repository
{
    public class QuestionRepository:IQuestionRepository
    {
        private readonly ApplicationDbContext _context;
        public QuestionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateQuestionAsync(QuestionTable question)
        {
            await _context.questionTables.AddAsync(question);
           _context.SaveChanges();
        }

        public IEnumerable<QuestionTable> GetAll()
        {
            return _context.questionTables;
        }

        public IEnumerable<QuestionTable> GetAllCSharpQuestion()
        {
            return _context.questionTables.Where(s=>s.CategoryId==1);
        }

        public IEnumerable<QuestionTable> GetAllHTMLQuestion()
        {
           return _context.questionTables.Where(s=>s.CategoryId == 2);
        }

        public IEnumerable<QuestionTable> GetAllTypeScriptQuestion()
        {
            return _context.questionTables.Where(s => s.CategoryId == 3);
        }

        public QuestionTable GetQuestionsById(int id)
        {
            return _context.questionTables.FirstOrDefault(q=>q.Question_Id == id);
           
        }

        public void  UpdateQuestion(QuestionTable question)
        {
            var QuestionsIndb = _context.questionTables.FirstOrDefault(q => q.Question_Id == question.Question_Id);
            
            if(QuestionsIndb!=null)
                {
                QuestionsIndb.QuestionText = question.QuestionText;
                QuestionsIndb.Option1 = question.Option1;
                QuestionsIndb.Option2 = question.Option2;
                QuestionsIndb.Option3 = question.Option3;
                QuestionsIndb.Option4 = question.Option4;
                QuestionsIndb.Answer = question.Answer;
                QuestionsIndb.CategoryId = question.CategoryId;
            }
            _context.SaveChanges();
        }
    }
}

