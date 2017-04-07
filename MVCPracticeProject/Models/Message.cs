using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPracticeProject.Models
{
    public class Message
    {
        public int id { get; set; }
        [Required]
        [StringLength(255)]
        public string message { get; set; }
    }
}