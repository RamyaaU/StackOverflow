using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverFlow.ViewModels
{
    public class QuestionViewModel
    {
        public int QuestionId { get; set; }

        public string QuestionName { get; set; }

        public DateTime QuestionDateAndTime { get; set; }

        public int UserId { get; set; }

        public int CategoryId { get; set; }

        public int VotesCount { get; set; }

        public int AnswersCount { get; set; }

        public int ViewsCount { get; set; }

        //user deatils will be stored, like to which user the question belongs to 
        //the question is asked by which user? the corresponding details will 
        //be stored in User property
        public UserViewModel User { get; set; }

        public CategoryViewModel Category { get; set; }

        public virtual List<AnswerViewModel> Answers { get; set; }
    }
}
