using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.MVC.Models;
using MyProject.VehicleService.Common;
using System.Threading.Tasks;
using MyProject.DTO.Common;
using System.Linq;
using System.Collections.Generic;
using MyProject.DTO;

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
        [HttpGet("VehicleMake/VehicleMake", Name = "vehicle-make")]
        public async Task<IActionResult> GetVehicleMakeAsync(string searchBy, string search, string sortBy, string sortType, int? page, int? pageSize)
        {
            page = page == null ? 1 : page;
            pageSize = pageSize == null ? 5 : pageSize;
            sortType = string.IsNullOrEmpty(sortType) ? "asc" : sortType;

            ViewBag.Sorting = sortType;
            ViewBag.SortBy = !string.IsNullOrEmpty(sortBy) ? sortBy : "Name";
            ViewBag.Search = !string.IsNullOrEmpty(search) ? search : "";
            ViewBag.SearchBy = !string.IsNullOrEmpty(searchBy) ? searchBy : "Name";
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;

            var filter = new Filter()
            {
                SearchBy = searchBy,
                Search = search,
                SortBy = sortBy,
                SortType = sortType

            };

            var paging = new Paging()
            {
                PageNumber = (int)page,
                PageSize = (int)pageSize
            };

            var result = await vehicleMakeService.GetAllMakesAsync(filter, paging);

            var vehicleMakes = (IEnumerable<IVehicleMakeDTO>)result["makes"];
            var pagination = (IPaging)result["paging"];

            var pageCount = pagination.TotalItemsCount / pageSize;
            ViewBag.TotalPageCount = pagination.TotalItemsCount % pageSize == 0 ? pageCount : pageCount + 1;


            if (vehicleMakes.Any())
            {
                return View(mapper.Map<IEnumerable<VehicleMakeViewModel>>(vehicleMakes));
            }
            else
            {
                ViewBag.Message = "There are no Vehicle Makes to show.";
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
        public async Task<IActionResult> AddVehicleMakeAsync(VehicleMakeViewModel vehicleMakeViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var vehicleMake = mapper.Map<IVehicleMakeDTO>(vehicleMakeViewModel);
                    vehicleMake.Id = Guid.NewGuid();
                    await vehicleMakeService.AddVehicleMakeAsync(vehicleMake);
                }
                else
                {
                    return RedirectToAction(nameof(AddVehicleMake));
                }
                return RedirectToAction(nameof(GetVehicleMakeAsync));
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
        public async Task<IActionResult> SubmitEditVehicleMakeAsync(VehicleMakeViewModel vehicleMakeViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await vehicleMakeService.UpdateVehicleMakeAsync(mapper.Map<IVehicleMakeDTO>(vehicleMakeViewModel));
                    return RedirectToAction(nameof(GetVehicleMakeAsync));
                }
                else
                    RedirectToAction(nameof(GetVehicleMakeAsync));
            }
            catch
            {
                return RedirectToAction(nameof(EditVehicleMake));
            }
            return RedirectToAction(nameof(EditVehicleMake));
        }

        [HttpGet("VehicleMake/DeleteVehicleMake", Name = "delete-vehicle-make")]
        public async Task<IActionResult> DeleteVehicleMakeAsync(VehicleMakeViewModel vehicleMakeViewModel)
        {
            try
            {
                await vehicleMakeService.DeleteVehicleMakeAsync(mapper.Map<IVehicleMakeDTO>(vehicleMakeViewModel));

                return RedirectToAction(nameof(GetVehicleMakeAsync));
            }
            catch(Exception e)
            {
                return View();
            }
        }
    }
}
