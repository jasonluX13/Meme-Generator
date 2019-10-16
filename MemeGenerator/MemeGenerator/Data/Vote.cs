using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MemeGenerator.Data
{
    public class Vote
    {
        public int Id { get; set; }
        [Required]
        public bool UpDown { get; set; } //true = upvote, false = downvote
        [Required]
        public int UserId { get; set; }
        [Required]
        public int MemeId { get; set; }
    }
}