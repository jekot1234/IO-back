using IO.Model;
using IO.Services.HallService;
using IO.Services.HallServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IO.Controllers
{

    [ApiController]
    [Route("/hall")]
    public class HallsController : Controller
    {

        private readonly IHallService hallService;

        public HallsController(HallService _hallService)
        {
            hallService = _hallService;
        }

        [HttpGet]
        [Route("/hall")]
        public List<Hall> GetHalls()
        {
            return hallService.GetHalls();
        }

    }
}
