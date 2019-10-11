using MemeGenerator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
//using System.Web.Mvc;

namespace MemeGenerator.ApiControllers
{
    public class ApiTemplateController : ApiController
    {
        private ITemplateRepository _repository;
    

        public ApiTemplateController(ITemplateRepository repository)
        {
            _repository = repository;
        }

        [Route("api/templates/all")]
        public List<Template> Get()
        {
            return _repository.GetAll();
        }

        
    }
}