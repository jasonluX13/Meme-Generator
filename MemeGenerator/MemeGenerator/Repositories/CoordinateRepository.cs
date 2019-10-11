using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemeGenerator.Data
{
    public class CoordinateRepository : ICoordinateRepository
    {
        public void Insert(Coordinates coord)
        {
            using(var context = new Context())
            {
                context.Coordinates.Add(coord);
                context.SaveChanges();
            }
        }
    }
}