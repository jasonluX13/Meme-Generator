using MemeGenerator.Data;
using MemeGenerator.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MemeGenerator.ApiControllers
{
    //[Authorize]
    public class ApiVoteController : ApiController
    {
        private IVoteRepository _repository;
        private IUserRepository _userRepository;

        public ApiVoteController(IVoteRepository repository, IUserRepository urepository)
        {
            _repository = repository;
            _userRepository = urepository;
        }

        [Route("api/votes/all"), HttpGet]
        public List<Vote> GetAllVotes()
        {
            return _repository.GetAllVotes();
        }

        [Route("api/votes/{memeId}/all"), HttpGet]
        public List<Vote> GetAllVotesOnMeme(int memeId)
        {
            return _repository.GetAllVotesOnMeme(memeId);
        }

        [Route("api/votes/{memeId}"), HttpGet]
        public Vote GetCurrentUserVote(int memeId)
        {
            if (!User.Identity.IsAuthenticated) return null;
            int userId = _userRepository.GetByUsername(User.Identity.Name).Id;
            return _repository.GetUserVoteOnMeme(memeId, userId);
        }


        [Authorize]
        [Route("api/votes/self/all"), HttpGet]
        public List<Vote> GetAllCurrentUserVotes()
        {
            if (!User.Identity.IsAuthenticated) return null;
            int userId = _userRepository.GetByUsername(User.Identity.Name).Id;
            return _repository.GetAllUserVotes(userId);
        }


        [Authorize]
        [Route("api/votes/{memeId}/add/{updown}"), HttpPut]
        public void CastUserVote(int memeId, bool updown)
        {

            if (!User.Identity.IsAuthenticated) return;
            Vote vote = new Vote()
            {
                UserId = _userRepository.GetByUsername(User.Identity.Name).Id,
                MemeId = memeId,
                UpDown = updown
            };
            _repository.AddVote(vote);
        }

    }
}