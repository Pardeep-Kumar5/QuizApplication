using QuizApplicationBackend.Data;
using QuizApplicationBackend.Model;
using QuizApplicationBackend.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace QuizApplicationBackend.Repository
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CategoryTable> GetAllCategory()
        {
            return _context.categories;
        }

        public CategoryTable GetCategoryById(int categoryId)
        {
            return _context.categories.Where(s => s.Id == categoryId).FirstOrDefault();
        }
    }
}
