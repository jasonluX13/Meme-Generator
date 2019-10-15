using MemeGenerator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemeGenerator.Repositories
{
    public interface IVoteRepository
    {
        void AddVote(Vote vote);
        Vote GetUserVoteOnMeme(int memeId);
    }
}