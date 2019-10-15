﻿using MemeGenerator.Data;
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

        [Route("api/votes/{memeId}/add/{updown}"), HttpPatch]
        public Vote CastUserVote(int memeId, bool updown)
        {
            if (!User.Identity.IsAuthenticated) return null;
            Vote vote = new Vote()
            {
                UserId = _userRepository.GetByUsername(User.Identity.Name).Id,
                MemeId = memeId,
                UpDown = updown
            };
            _repository.AddVote(vote);
            return vote;
        }



    }
}