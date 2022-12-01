﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StackOverFlow.ViewModels
{
    public class VoteViewModel
    {
        public int VoteId { get; set; }

        public int UserId { get; set; }

        public int AnswerId { get; set; }

        public int VoteValue { get; set; }
    }
}
