using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LoginReg.Models;

namespace LoginReg.Models
{
    public class User : BaseEntity
    {   
        public int UserId { get; set; } 
        public string FName { get; set; } 
        public string LName { get; set; } 
        public string Email { get; set; } 
        public string Password { get; set; }
    }
}