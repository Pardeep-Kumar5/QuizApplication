using System.ComponentModel.DataAnnotations;

namespace QuizApplicationBackend.Model
{
    public class CategoryTable
    {
        [Key]
        public int Id { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
    }
}
