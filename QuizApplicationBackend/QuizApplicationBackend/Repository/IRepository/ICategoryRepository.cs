using QuizApplicationBackend.Model;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizApplicationBackend.Repository.IRepository
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryTable> GetAllCategory();
        CategoryTable GetCategoryById(int categoryId);
    }
}
