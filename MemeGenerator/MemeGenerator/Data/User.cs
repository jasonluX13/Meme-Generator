using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MemeGenerator.Data
{
    public class User
    {

        int Id { get; set; }
        [Required]
        string Username { get; set; }
        [Required]
        string HashedPassword { get; set; }

    }
}