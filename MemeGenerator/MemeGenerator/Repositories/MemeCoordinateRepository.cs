using MemeGenerator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemeGenerator.Repositories
{
    public class MemeCoordinateRepository : IMemeCoordinateRepository
    {
        public void Insert(MemeCoordinates memeCoords)
        {
            using (var context = new Context())
            {
                context.MemeCoordinates.Add(memeCoords);
                context.SaveChanges();
            }
        }
    }
}