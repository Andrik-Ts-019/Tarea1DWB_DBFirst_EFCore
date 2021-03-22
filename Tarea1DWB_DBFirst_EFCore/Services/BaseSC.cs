using System;
using System.Collections.Generic;
using System.Text;
using Tarea1DWB_DBFirst_EFCore.DataAccess;

namespace Tarea1DWB_DBFirst_EFCore.Services
{
    public class BaseSC
    {
        public NorthwindContext dbContext = new NorthwindContext();
    }
}
