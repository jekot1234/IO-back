using IO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IO.Services.HallService
{
    public interface IHallService
    {
        List<Hall> GetHalls();
    }
}
