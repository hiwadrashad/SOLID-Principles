using SOLID_Principles_LIB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principles_LIB.Interfaces
{
    public interface IBack_Stage_Pass
    {
        public void BackstagePassAboveZeroDaysSell(IList<Item> Items, int i);
    }
}
