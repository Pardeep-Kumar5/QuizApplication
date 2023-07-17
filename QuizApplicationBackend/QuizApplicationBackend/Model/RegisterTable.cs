using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApplicationBackend.Model
{

    public class RegisterTable
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool Status { get; set; }
        [NotMapped]
        public string Token { get; set; }
    }
}
