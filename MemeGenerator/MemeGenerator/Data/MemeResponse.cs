using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MemeGenerator.Data
{
    public class MemeResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        [Display(Name ="Creator Username")]
        public string CreatorUsername { get; set; }
        public List<Comment> Comments { get; set; }
        public List<MemeCoordInfo> MemeCoordinates { get; set; }
        
        public byte[] ImageBytes { get; set; } 

        public MemeResponse()
        {

        }

        public MemeResponse(Meme meme)
        {
            Id = meme.Id;
            Title = meme.Title;
            Url = meme.Url;
            Comments = meme.Comments;
            MemeCoordinates = meme.MemeCoordinates.Select(m => new MemeCoordInfo { Id = m.Id, Text = m.Text, X = m.X, Y=m.Y}).ToList();
            CreatorUsername = meme.Creator.Username;
            ImageBytes = meme.ImageBytes;
        }
    }
}