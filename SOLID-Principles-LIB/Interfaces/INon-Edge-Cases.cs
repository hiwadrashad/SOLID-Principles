using SOLID_Principles_LIB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principles_LIB.Interfaces
{
    public interface INon_Edge_Cases
    {
        bool NonEdgeCasesAboveZeroQuality(IList<Item> Items, int i);
    }
}
