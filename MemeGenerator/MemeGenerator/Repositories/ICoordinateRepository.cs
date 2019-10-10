using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGenerator.Data
{
    public interface ICoordinateRepository
    {
        void Insert(Coordinates coord);
    }
}
