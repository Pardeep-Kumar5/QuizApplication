using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplicationBackend.MappingProfile.DTOs
{
    public class QuestionDto
    {
        public int Question_Id { get; set; }
        public string QuestionText { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string Answer { get; set; }

    }
}
