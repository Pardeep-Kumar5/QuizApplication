using Microsoft.EntityFrameworkCore;
using QuizApplicationBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplicationBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<RegisterTable> RegisterTable { get; set; }
        public DbSet<QuestionTable> questionTables { get; set; }
        public DbSet<CategoryTable> categories { get; set; }
        public DbSet <ScoreTable> StudentScoreTable { get; set; }
    }
}
