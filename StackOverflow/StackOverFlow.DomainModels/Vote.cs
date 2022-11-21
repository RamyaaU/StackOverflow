using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverFlow.DomainModels
{
    public class Vote
    {
        //identity insert
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VoteId { get; set; }

        public int UserId { get; set; }

        public int AnswerId { get; set; }

        public int VoteValue { get; set; }
    }
}
