using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CgiQuiz.Models
{
    public class Question
    {
        [Key]
        public int QuestionID { get; set; }
        [Required]
        public string QuestionText { get; set; }
        [Required]
        public string AnswerA { get; set; }
        [Required]
        public string AnswerB { get; set; }
        [Required]
        public string AnswerC { get; set; }
        [Required]
        public string AnswerD { get; set; }
        [Required]
        public string CorrectAnswer { get; set; }


    }
}
