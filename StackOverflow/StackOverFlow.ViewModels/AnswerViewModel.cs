using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StackOverFlow.ViewModels
{
    public class AnswerViewModel
    {
        public int AnswerId { get; set; }

        public string AnswerText { get; set; }

        public DateTime AnswerDateAndTime { get; set; }

        public int UserId { get; set; }
        public int QuestionId { get; set; }

        public int VotesCount { get; set; }
        //type of the vote given by current user
        public int CurrentUserVoteType { get; set; }

        //the properties you are retreiving from other table / property
        //must be virtual 
        public virtual UserViewModel User { get; set; }
        public virtual List<VoteViewModel> Votes { get; set; }
    }
}
