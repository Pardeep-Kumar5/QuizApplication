using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplicationBackend.MappingProfile.DTOs
{
    public class RegisterDto
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        //public bool Status { get; set; }
    }
}
