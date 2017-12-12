using System;
using System.ComponentModel.DataAnnotations;

namespace LoginReg.Models
{
    public abstract class BaseEntity 
    {
        public DateTime Created_At { get; set; } = DateTime.Now;
        public DateTime Updated_At { get; set; } = DateTime.Now;
    }
}