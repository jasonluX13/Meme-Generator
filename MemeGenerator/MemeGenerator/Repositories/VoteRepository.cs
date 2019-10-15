using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MemeGenerator.Data;
using System.Threading.Tasks;

namespace MemeGenerator.Repositories
{
    public class VoteRepository : IVoteRepository
    {
        
        async public void AddVote(Vote vote)
        {
            using(var context = new Context())
            {
                Vote oldVote = GetUserVoteOnMeme(vote.MemeId, vote.UserId);
                if(oldVote != null)
                {
                    if (oldVote.UpDown == vote.UpDown) return;
                    else context.Votes.Remove(oldVote);
                }
                else context.Votes.Add(vote);
                await context.SaveChangesAsync();
            }
        }

        public Vote GetUserVoteOnMeme(int memeId, int userId)
        {
            using(var context = new Context())
            {
                return context.Votes.SingleOrDefault(x => x.MemeId == memeId && x.UserId == userId);
            }
        }

        public List<Vote> GetAllVotesOnMeme(int memeId)
        {
            using(var context = new Context())
            {
                return context.Votes.Where(x => x.MemeId == memeId).ToList();
            }
        }
    }
}