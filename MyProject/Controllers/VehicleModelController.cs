using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.DTO.Common;
using MyProject.MVC.Models;
using MyProject.VehicleService.Common;

namespace MyProject.MVC.Controllers
{
    public class VehicleModelController : Controller
    {
        private readonly IVehicleModelService vehicleModelService;
        private readonly IVehicleMakeService vehicleMakeService;
        private readonly IMapper mapper;

        public VehicleModelController(IVehicleModelService vehicleModelService, IMapper mapper, IVehicleMakeService vehicleMakeService)
        {
            this.vehicleModelService = vehicleModelService;
            this.vehicleMakeService = vehicleMakeService;
            this.mapper = mapper;
        }

        [HttpGet("VehicleModel/VehicleModel", Name = "vehicle-model")]
        public async Task<IActionResult> GetVehicleModelsAsync(string searchBy, string search, string sortBy, string sortType, int? page, int? pageSize)
        {
            page = page == null ? 1 : page;
            pageSize = pageSize == null ? 4 : pageSize;

            sortType = string.IsNullOrEmpty(sortType) ? "asc" : sortType;
            ViewBag.Sorting = sortType;
            ViewBag.Search = !string.IsNullOrEmpty(search) ? search : "";
            ViewBag.SearchBy = !string.IsNullOrEmpty(searchBy) ? searchBy : "Name";
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;

            var result = await vehicleModelService.GetAllModelsAsync(searchBy, search, sortBy, sortType, (int)page, (int)pageSize);

            var vehicleModels = (IEnumerable<IVehicleModelDTO>)result["models"];
            var paging = (IPaging)result["paging"];

            var pageCount = paging.TotalItemsCount / pageSize;
            ViewBag.TotalPageCount = paging.TotalItemsCount % pageSize == 0 ? pageCount : pageCount + 1;

            if (vehicleModels.Any())
            {
                return View(mapper.Map<IEnumerable<VehicleModelViewModel>>(vehicleModels));
            }
            else
            {
                ViewBag.Message = "There are no Vehicle Models to show.";
                return View();
            }

        }

        [HttpGet("VehicleModel/AddVehicleModel", Name = "add-vehicle-model")]
        public IActionResult AddVehicleModel(Guid id)
        {
            ViewBag.Message = id;
            return View();
        }

        [HttpPost("VehicleModel/AddVehicleModel", Name = "submit-add-vehicle-model")]
        public async Task<IActionResult> AddVehicleModelAsync(VehicleModelViewModel vehicleModelViewModel)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var vehicleModel = mapper.Map<IVehicleModelDTO>(vehicleModelViewModel);
                    vehicleModel.Id = Guid.NewGuid();
                    vehicleModel.VehicleMake = await vehicleMakeService.GetVehicleMakeAsync(vehicleModel.VehicleMakeId);
                    await vehicleModelService.AddVehicleModelAsync(vehicleModel);
                }
                else
                {
                    return RedirectToAction(nameof(AddVehicleModel));
                }
                return RedirectToAction(nameof(GetVehicleModelsAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleModel/Edit
        [HttpGet("VehicleModel/EditVehicleModel", Name = "edit-vehicle-model")]
        public ActionResult EditVehicleModel(VehicleModelViewModel vehicleModelViewModel)
        {
            return View(vehicleModelViewModel);
        }

        // POST: VehicleModel/Edit
        [HttpPost("VehicleModel/SubmitEditVehicleModel", Name = "submit-edit-vehicle-model")]
        public async Task<IActionResult> SubmitEditVehicleModelAsync(VehicleModelViewModel vehicleModelViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await vehicleModelService.UpdateVehicleModelAsync(mapper.Map<IVehicleModelDTO>(vehicleModelViewModel));
                    return RedirectToAction(nameof(GetVehicleModelsAsync));
                }
                else
                    RedirectToAction(nameof(GetVehicleModelsAsync));
            }
            catch
            {
                return RedirectToAction(nameof(GetVehicleModelsAsync));
            }
            return RedirectToAction(nameof(GetVehicleModelsAsync));
        }

        // GET: VehicleModel/Delete
        [HttpGet("VehicleModel/DeleteVehicleModel", Name = "delete-vehicle-model")]
        public async Task<IActionResult> DeleteVehicleModelAsync(VehicleModelViewModel vehicleModelViewModel)
        {
            try
            {
                await vehicleModelService.DeleteVehicleModelAsync(mapper.Map<IVehicleModelDTO>(vehicleModelViewModel));

                return RedirectToAction(nameof(GetVehicleModelsAsync));
            }
            catch
            {
                return View();
            }
        }
    }
}