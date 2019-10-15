using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MemeGenerator.Data;

namespace MemeGenerator.Repositories
{
    public class VoteRepository : IVoteRepository
    {
        
        async public void AddVote(Vote vote)
        {
            using(var context = new Context())
            {
                context.Votes.Add(vote);
                await context.SaveChangesAsync();
            }
        }

        public Vote GetUserVoteOnMeme(int memeId)
        {
            using(var context = new Context())
            {
               
            }
        }
    }
}