using System;
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

        // GET: VehicleModel
        public async Task<IActionResult> VehicleModel(string searchBy, string search, string sortBy, string sortType, int? page, int? pageSize)
        {
            page = page == null ? 1 : page;
            pageSize = pageSize == null ? 4 : pageSize;

            sortType = string.IsNullOrEmpty(sortType) ? "asc" : sortType;
            ViewBag.Sorting = sortType;
            ViewBag.Search = !string.IsNullOrEmpty(search) ? search : "";
            ViewBag.SearchBy = !string.IsNullOrEmpty(searchBy) ? searchBy : "Name";
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            var model = await vehicleModelService.GetAllModelsAsync(searchBy, search, sortBy, sortType, (int)page, (int)pageSize);

            var pageCount = model.TotalItemsCount / pageSize;
            ViewBag.TotalPageCount = model.TotalItemsCount % pageSize == 0 ? pageCount : pageCount + 1;

            if (model.VehicleModels.Any())
            {
                return View(mapper.Map<VehicleModelViewModel>(model));
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
        public async Task<IActionResult> AddVehicleModel(VehicleModelViewModel vehicleModelViewModel)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var vehicleModel = mapper.Map<IVehicleModelModel>(vehicleModelViewModel);
                    vehicleModel.Id = Guid.NewGuid();
                    vehicleModel.VehicleMake = await vehicleMakeService.GetVehicleMakeAsync(vehicleModel.VehicleMakeId);
                    await vehicleModelService.AddVehicleModelAsync(vehicleModel);
                }
                else
                {
                    return RedirectToAction(nameof(AddVehicleModel));
                }
                return RedirectToAction(nameof(VehicleModel));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleModel/Edit/5
        [HttpGet("VehicleModel/EditVehicleModel", Name = "edit-vehicle-model")]
        public ActionResult EditVehicleModel(VehicleModelViewModel vehicleModelViewModel)
        {
            return View(vehicleModelViewModel);
        }

        // POST: VehicleModel/Edit/5
        [HttpPost("VehicleModel/SubmitEditVehicleModel", Name = "submit-edit-vehicle-model")]
        public async Task<IActionResult> SubmitEditVehicleModel(VehicleModelViewModel vehicleModelViewModel)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    await vehicleModelService.UpdateVehicleModelAsync(mapper.Map<IVehicleModelModel>(vehicleModelViewModel));
                    return RedirectToAction(nameof(VehicleModel));
                }
                else
                    RedirectToAction(nameof(VehicleModel));
            }
            catch
            {
                return RedirectToAction(nameof(VehicleModel));
            }
            return RedirectToAction(nameof(VehicleModel));
        }

        // GET: VehicleModel/Delete/5
        [HttpGet("VehicleModel/DeleteVehicleModel", Name = "delete-vehicle-model")]
        public async Task<IActionResult> DeleteVehicleModel(VehicleModelViewModel vehicleModelViewModel)
        {
            try
            {
                // TODO: Add delete logic here
                await vehicleModelService.DeleteVehicleModelAsync(mapper.Map<IVehicleModelModel>(vehicleModelViewModel));

                return RedirectToAction(nameof(VehicleModel));
            }
            catch
            {
                return View();
            }
        }
    }
}