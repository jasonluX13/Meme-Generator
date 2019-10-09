using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MemeGenerator.ViewModels
{
    public class CreateTemplate
    {
        [Required]
        public string Title { get; set; }
        [Required]
        [Url]
        public string Url { get; set; }
    }
}