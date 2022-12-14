using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverFlow.DomainModels
{
    public class User
    {
        //identity insert
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string Name { get; set; }

        public string Mobile { get; set; }

        public bool isAdmin { get; set; }
    }
}
