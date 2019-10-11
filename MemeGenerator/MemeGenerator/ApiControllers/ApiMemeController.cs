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

        public ApiMemeController(IMemeRepository memeRepo)
        {
            _memeRepo = memeRepo;
        }

        [Route("api/memes/all")]
        async public Task<List<MemeResponse>> Get()
        {
            return await _memeRepo.GetAllMemesAsync();
        }
    }
}
