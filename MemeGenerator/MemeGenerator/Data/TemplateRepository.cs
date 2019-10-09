using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MemeGenerator.Data
{
    public class TemplateRepository : ITemplateRepository
    {
        public List<Template> GetAll()
        {
            using(var context = new Context())
            {
                return context.Templates
                    .Include(t => t.Coordinates)
                    .ToList();
            }
        }
    }
}