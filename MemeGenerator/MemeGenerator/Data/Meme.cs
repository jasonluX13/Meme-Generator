using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MemeGenerator.Data
{
    public class Meme
    {
        public Meme()
        {
            Comments = new List<Comment>();
        }
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public int CreatorId { get; set; }
        public User Creator { get; set; }
        public List<Comment> Comments { get; set; }


    }
}