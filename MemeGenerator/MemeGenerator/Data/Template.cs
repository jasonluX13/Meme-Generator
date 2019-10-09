using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MemeGenerator.Data
{
    public class Template
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Url { get; set; }
        public List<Coordinates> Coordinates { get; set; }

        public Template()
        {
            Coordinates = new List<Coordinates>();
        }
    }
}