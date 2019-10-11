using MemeGenerator.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MemeGenerator.ViewModels
{
    public class CreateMeme
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Url { get; set; }

        public List<Coordinates> Coordinates { get; set; }
    }
}