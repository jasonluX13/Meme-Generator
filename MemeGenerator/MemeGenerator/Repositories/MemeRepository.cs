﻿using System;
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
                return await context.Templates
                    .OrderByDescending(t => t.Id)
                    .ToListAsync();
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
                    .Include(x => x.Comments)
                    .Include(x => x.Votes)
                    .OrderByDescending(x => x.Id)
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
                    .Include(x => x.Votes)
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

        async public Task<Comment> GetCommentById(int id)
        {
            using (var context = new Context())
            {
                return await context.Comments
                    .Include(c => c.Meme)
                    .Include(c => c.Creator)
                    .Where(c => c.Id == id)
                    .SingleOrDefaultAsync();
            }
        }
        async public void RemoveCommentAsync(Comment comment)
        {
            using (var context = new Context())
            {
                context.Comments.Attach(comment);
                context.Entry(comment).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public int Count()
        {
            using (var context = new Context())
            {
                return context.Memes.Count();
            }
        }

        public void RemoveMeme(Meme meme)
        {
            using (var context = new Context())
            {
                context.Memes.Attach(meme);
                context.Memes.Remove(meme);
                context.SaveChanges();
            }
        }
        public Meme GetMemeById(int id)
        {
            using (var context = new Context())
            {
                return context.Memes
                    .Include(m => m.MemeCoordinates)
                    .Include(m => m.Comments)
                    .Include(m => m.Creator)
                    .Where(m => m.Id == id)
                    .SingleOrDefault();
            }
        }
        
    }
}