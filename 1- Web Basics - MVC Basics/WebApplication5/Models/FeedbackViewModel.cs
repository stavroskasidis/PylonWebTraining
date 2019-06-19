using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class FeedbackViewModel
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string FeedbackText { get; set; }
    }
}