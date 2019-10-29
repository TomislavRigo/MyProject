using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using MyProject.MVC.Models;
using MyProject.VehicleService.Common;

namespace MyProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVehicleMakeService vehicleMakeService;
        private readonly IMapper mapper; 

        public HomeController(IVehicleMakeService vehicleMakeService, IMapper mapper)
        {
            this.vehicleMakeService = vehicleMakeService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            //var response = mapper.Map<VehicleMakeViewModel>(await vehicleMakeService.GetVehicleMakeAsync(Guid.NewGuid()));
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
