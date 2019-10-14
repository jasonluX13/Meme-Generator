using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MemeGenerator.Data
{
    public class MemeRepository : IMemeRepository
    {
        async public Task<List<Template>> GetAllTemplatesAsync()
        {
            using (var context = new Context())
            {
                return await context.Templates.ToListAsync();
            }
        }

        async public Task<Template> GetSingleTemplate(int id)
        {
            using(var context = new Context())
            {
                return await context.
                    Templates
                    .Include(x => x.Coordinates)
                    .SingleOrDefaultAsync(x => x.Id == id);
            }
        }

        async public Task<Template> AddTemplateAsync(string title, string url, List<Coordinates> coordinates)
        {
            using (var context = new Context())
            {
                Template newTemplate = new Template();
                newTemplate.Coordinates = coordinates;
                newTemplate.Title = title;
                newTemplate.Url = url;
                context.Templates.Add(newTemplate);
                await context.SaveChangesAsync();
                return newTemplate; 
            }
        }

        async public Task<List<MemeResponse>> GetAllMemesAsync()
        {
            using (var context = new Context())
            {
                var memes = await context.Memes
                    .Include(x => x.Creator)
                    .Include(x => x.MemeCoordinates)
                    .ToListAsync();
                List<MemeResponse> memeresponses = new List<MemeResponse>();
                foreach (var meme in memes)
                {
                    memeresponses.Add(new MemeResponse(meme));
                }
                return memeresponses;
            }
        }

        async public Task<MemeResponse> GetMemeAsync(int id)
        {
            using(var context = new Context())
            {
                var meme = await context
                    .Memes
                    .Include(x => x.Comments)
                    .Include(x => x.Creator)
                    .Include(x => x.MemeCoordinates)
                    .SingleOrDefaultAsync(x => x.Id == id);

                var comments = await context.Comments.Include(x => x.Creator).Where(x => id == x.MemeId).ToListAsync();

                meme.Comments = comments; 

                return new MemeResponse(meme);
            }
        }

        async public Task<MemeResponse> AddMemeAsync(Meme meme)
        {
            using(var context = new Context())
            {
                context.Memes.Add(meme);
                await context.SaveChangesAsync();
                return new MemeResponse(meme);
            }
        }

        public int AddMeme(Meme meme)
        {
            using (var context = new Context())
            {
                context.Memes.Add(meme);
                context.SaveChanges();
                return meme.Id;
            }
        }
        async public Task<Comment> AddCommentAsync(Comment comment)
        {
            using (var context = new Context())
            {
                context.Comments.Add(comment);
                await context.SaveChangesAsync();
                return comment;
            }
        }

        public int Count()
        {
            using (var context = new Context())
            {
                return context.Memes.Count();
            }
        }

        
    }
}