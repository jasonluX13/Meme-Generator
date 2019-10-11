using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MemeGenerator.Data
{
    public class MemeCoordinates
    {
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        [Required]
        public string Text { get; set; }

        public int MemeId { get; set; }
        public Meme Meme{ get; set; }
    }
}