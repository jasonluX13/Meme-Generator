using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemeGenerator.Data
{
    public interface ITemplateRepository
    {
        List<Template> GetAll();
        Template GetById(int id);
    }
}