using Microsoft.EntityFrameworkCore;
using QuizApplicationBackend.Data;
using QuizApplicationBackend.Migrations;
using QuizApplicationBackend.Model;
using QuizApplicationBackend.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace QuizApplicationBackend.Repository
{
    public class ParticipantRepository:IParticipantRepository
    {
        private ApplicationDbContext _context;
        public ParticipantRepository(ApplicationDbContext context)
        {
                _context=context;
        }

        public void AddParticipant(ScoreTable quiz)
        {

                _context.StudentScoreTable.Add(quiz);
                _context.SaveChanges();
        }

      
    }
}
