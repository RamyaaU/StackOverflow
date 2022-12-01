using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StackOverFlow.ViewModels
{
    public class EditAnswerViewModel
    {
        [Required]
        public int AnswerId { get; set; }
        [Required]
        public string AnswerText { get; set; }
        [Required]
        public DateTime AnswerDateAndTime { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int QuestionId { get; set; }

        [Required]
        public int VotesCount { get; set; }
    }
}
