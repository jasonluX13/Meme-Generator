using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemeGenerator.Data
{
    public class MemeResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string CreatorUsername { get; set; }
        public List<Comment> Comments { get; set; }
        public MemeResponse(Meme meme)
        {
            Id = meme.Id;
            Title = meme.Title;
            Url = meme.Url;
            Comments = meme.Comments;
            CreatorUsername = meme.Creator.Username;
        }
    }
}