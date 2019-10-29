using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.DAL;
using MyProject.MVC.Models;
using MyProject.VehicleService.Common;
using System.Threading.Tasks;
using MyProject.DTO.Common;
using System.Linq;

namespace MyProject.MVC.Controllers
{
    public class VehicleMakeController : Controller
    {
        private readonly IVehicleMakeService vehicleMakeService;
        private readonly IMapper mapper;

        public VehicleMakeController(IVehicleMakeService vehicleMakeService, IMapper mapper)
        {
            this.vehicleMakeService = vehicleMakeService;
            this.mapper = mapper;
        }

        // GET: VehicleMake
        public async Task<IActionResult> VehicleMake()
        {
            var make = await vehicleMakeService.GetAllMakesAsync();
            if(make.VehicleMakes.Any())
            {
                return View(mapper.Map<VehicleMakeViewModel>(make));
            }
            else
            {
                ViewBag.Message = "There is no Vehicle Make to show. \n Please add some.";
                return View();
            }
        }

        // GET: VehicleMake/AddVehicleMake
        [HttpGet(Name = "add-vehicle-make")]
        public ActionResult AddVehicleMake()
        {
            return View();
        }

        // POST: VehicleMake/AddVehicleMake
        [HttpPost]
        public async Task<IActionResult> AddVehicleMake(VehicleMakeViewModel vehicleMakeViewModel)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var vehicleMake = mapper.Map<IVehicleMakeModel>(vehicleMakeViewModel);
                    vehicleMake.Id = Guid.NewGuid();
                    await vehicleMakeService.AddVehicleMakeAsync(vehicleMake);
                }
                else
                {
                    return RedirectToAction(nameof(AddVehicleMake));
                }
                return RedirectToAction(nameof(VehicleMake));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet("VehicleMake/EditVehicleMake", Name = "edit-vehicle-make")]
        public ActionResult EditVehicleMake(VehicleMakeViewModel vehicleMakeViewModel)
        {
            {
                return View(vehicleMakeViewModel);
            }
        }

        // POST: VehicleMake/Edit/5
        [HttpPost("VehicleMake/SubmitEditVehicleMake", Name = "submit-edit-vehicle-make")]
        public async Task<IActionResult> SubmitEditVehicleMake(VehicleMakeViewModel vehicleMakeViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await vehicleMakeService.UpdateVehicleMakeAsync(mapper.Map<IVehicleMakeModel>(vehicleMakeViewModel));
                    return RedirectToAction(nameof(VehicleMake));
                }
                else
                    RedirectToAction(nameof(VehicleMake));
            }
            catch
            {
                return RedirectToAction(nameof(EditVehicleMake));
            }
            return RedirectToAction(nameof(EditVehicleMake));
        }

        [HttpGet("VehicleMake/DeleteVehicleMake", Name = "delete-vehicle-make")]
        public async Task<IActionResult> DeleteVehicleMake(VehicleMakeViewModel vehicleMakeViewModel)
        {
            try
            {
                // TODO: Add delete logic here
                await vehicleMakeService.DeleteVehicleMakeAsync(mapper.Map<IVehicleMakeModel>(vehicleMakeViewModel));

                return RedirectToAction(nameof(VehicleMake));
            }
            catch
            {
                return View();
            }
        }
    }
}
