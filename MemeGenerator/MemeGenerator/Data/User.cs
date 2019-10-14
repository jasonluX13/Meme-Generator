using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MemeGenerator.Data
{
    public class User
    {
        public User()
        {
            Memes = new List<Meme>();
        }
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string HashedPassword { get; set; }

        public List<Meme> Memes { get; set; }
        public List<UserRole> Roles { get; set; }

    }
}