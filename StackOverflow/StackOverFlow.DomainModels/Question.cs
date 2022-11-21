using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StackOverFlow.DomainModels
{
    public class Question
    {
        //identity insert
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get; set; }

        public string QuestionName { get; set; }    
        public DateTime QuestionDateAndTime { get; set; }

        public int UserId { get; set; }

        public int CategoryId { get; set; }

        public int VotesCount { get; set; }

        public int AnswersCount { get; set; }
        public int ViewsCount { get; set; }

        //virtual property called user of user type 
        //which represents the corresponding user details that are 
        //based on user id 

        //the problem is User property is no longer binded to the particular column, UserId, so 
        //we have to specify the foreign key of that column name.

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        
        public virtual List<Answer> Answers { get; set; }
    }
}
