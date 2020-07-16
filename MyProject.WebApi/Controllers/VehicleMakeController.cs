using System;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.DTO;
using MyProject.DTO.Common;
using MyProject.VehicleService.Common;
using MyProject.WebApi.Models;

namespace MyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleMakeController : ControllerBase
    {
        private readonly IVehicleMakeService vehicleMakeService;
        private readonly IMapper mapper;

        public VehicleMakeController(IVehicleMakeService vehicleMakeService, IMapper mapper)
        {
            this.vehicleMakeService = vehicleMakeService;
            this.mapper = mapper;
        }

        // GET: api/VehicleMake
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] QueryParams queryParams)
        {
            var filter = new Filter(queryParams.SearchBy, queryParams.Search);
            var sorting = new Sorting(queryParams.SortBy, queryParams.SortType);
            var paging = new Paging(queryParams.PageNumber, queryParams.PageSize);

            dynamic obj = new ExpandoObject();
            obj.VehicleMakes = await vehicleMakeService.GetAllMakesAsync(filter, paging, sorting);
            obj.Pagination = paging;
            obj.Filter = filter;
            obj.Sorting = sorting;

            return Ok(JsonSerializer.Serialize(obj));
        }
        // POST: api/VehicleMake
        [HttpPost]
        [Route("Add")]
        public async Task<HttpResponseMessage> PostAsync([FromQuery] QueryParams queryParams)
        {
            var vehicleMake = mapper.Map<IVehicleMakeDTO>(queryParams);
            vehicleMake.Id = Guid.NewGuid();

            await vehicleMakeService.AddVehicleMakeAsync(vehicleMake);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // PUT: api/VehicleMake/5
        [HttpGet]
        [Route("Edit")]
        public async Task<IActionResult> GetUpdateAsync([FromQuery] Guid id)
        {
            var result = await vehicleMakeService.GetVehicleMakeAsync(id);

            return Ok(JsonSerializer.Serialize(result));
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<HttpResponseMessage> UpdateAsync([FromQuery] QueryParams queryParams)
        {
            var vehicleMake = mapper.Map<IVehicleMakeDTO>(queryParams);

            await vehicleMakeService.UpdateVehicleMakeAsync(vehicleMake);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // DELETE: api/ApiWithActions/5
        [HttpGet]
        [Route("Delete")]
        public async Task<IActionResult> GetDeleteAsync(Guid id)
        {
            return Ok(JsonSerializer.Serialize(await vehicleMakeService.GetVehicleMakeAsync(id)));
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<HttpResponseMessage> DeleteAsync(Guid id)
        {
            await vehicleMakeService.DeleteVehicleMakeAsync(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}