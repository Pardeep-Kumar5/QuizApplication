using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuizApplicationBackend.Model
{
    public class ScoreTable
    {
        [Key]
        public int ScoreID { get; set; }
        public int Score { get; set; }
        public int TimeSpent { get; set; }
        public int RegisterId { get; set; }
        [ForeignKey("RegisterId")]
        public RegisterTable registerTable { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public CategoryTable CategoryTable { get; set; }
    }
}
