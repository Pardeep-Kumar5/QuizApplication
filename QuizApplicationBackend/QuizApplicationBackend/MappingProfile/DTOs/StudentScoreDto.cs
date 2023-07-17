using QuizApplicationBackend.Model;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApplicationBackend.MappingProfile.DTOs
{
    public class StudentScoreDto
    {
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
