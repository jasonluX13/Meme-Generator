using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MemeGenerator.Data
{
    public interface IMemeRepository
    {
        Task<List<Template>> GetAllTemplatesAsync();
        Task<Template> GetSingleTemplate(int id);
        Task<Template> AddTemplateAsync(string title, string url, List<Coordinates> coordinates);
        Task<List<MemeResponse>> GetAllMemesAsync();
        Task<MemeResponse> GetMemeAsync(int id);
        Task<MemeResponse> AddMemeAsync(Meme meme);
        Task<Comment> AddCommentAsync(Comment comment);
        void RemoveCommentAsync(Comment comment);
        int Count();
        Task<Comment> GetCommentById(int id);
        int AddMeme(Meme meme);
        void RemoveMeme(Meme meme);
        Meme GetMemeById(int id);
    }
}