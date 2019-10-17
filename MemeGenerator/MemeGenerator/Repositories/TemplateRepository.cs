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
                    .OrderByDescending(t => t.Id)
                    .ToList();
            }
        }

        public Template GetById(int id)
        {
            using (var context = new Context())
            {
                return context.Templates
                    .Include(t => t.Coordinates)
                    .Where(t => t.Id == id)
                    .SingleOrDefault();                   
            }
        }

        public int Insert(Template template)
        {
            using (var context = new Context())
            {
                context.Templates.Add(template);
                context.SaveChanges();
                return template.Id;
            }
        }

        public void Remove(Template template)
        {
            using (var context = new Context())
            {
                context.Templates.Attach(template);
                context.Entry(template).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}