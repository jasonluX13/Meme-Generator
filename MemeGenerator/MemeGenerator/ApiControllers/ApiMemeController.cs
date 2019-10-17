using MemeGenerator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MemeGenerator.ApiControllers
{
    public class ApiMemeController : ApiController
    {
        private IMemeRepository _memeRepo;
        private IUserRepository _userRepo;

        public ApiMemeController(IMemeRepository memeRepo, IUserRepository userRepo)
        {
            _memeRepo = memeRepo;
            _userRepo = userRepo;
        }

        [Route("api/memes/all"), HttpGet]
        async public Task<List<MemeResponse>> GetAllMemes()
        {
            return await _memeRepo.GetAllMemesAsync();
        }

        [Route("api/memes/meme/{id}"), HttpPost]
        async public Task<MemeResponse> GetSingleMeme(int id)
        {
            return await _memeRepo.GetMemeAsync(id);
        }
        [Authorize]
        [Route("api/memes/meme/{id}/{text}"), HttpPatch]
        async public void AddComment(int id, string text)
        {
            int userId = _userRepo.GetByUsername(User.Identity.Name).Id;
            Comment comment = new Comment
            {
                MemeId = id,
                CreatorId = userId,
                Text = text
            };
            await _memeRepo.AddCommentAsync(comment);
        }
    }
}
