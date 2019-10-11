using MemeGenerator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGenerator.Repositories
{
    public interface IMemeCoordinateRepository
    {
        void Insert(MemeCoordinates memeCoords);
    }
}
