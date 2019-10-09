using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MemeGenerator.Data
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public int CreatorId { get; set; }
        [Required]
        public int MemeId { get; set; }
        public User Creator { get; set; }
        public Meme Meme { get; set; }
    }
}