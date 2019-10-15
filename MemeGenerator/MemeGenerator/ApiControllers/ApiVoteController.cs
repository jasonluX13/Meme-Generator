using MemeGenerator.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MemeGenerator.ApiControllers
{
    [Authorize]
    public class ApiVoteController : ApiController
    {
        private IVoteRepository _repository;

        public ApiVoteController(IVoteRepository repository)
        {
            _repository = repository;
        }




    }
}