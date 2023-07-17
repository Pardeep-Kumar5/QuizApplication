using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApplicationBackend.Model
{
    public class QuestionTable
    {
        [Key]
        public int Question_Id { get; set; }
        public string QuestionText { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public int Answer { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public CategoryTable categoryTable { get; set; }
    }
}
