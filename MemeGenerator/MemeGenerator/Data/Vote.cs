using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MemeGenerator.Data
{
    public class Vote
    {
        int Id { get; set; }
        [Required]
        bool UpDown { get; set; } //true = upvote, false = downvote
        [Required]
        int UserId { get; set; }
        [Required]
        int MemeId { get; set; }
    }
}