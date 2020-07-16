using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.DTO;
using MyProject.DTO.Common;
using MyProject.VehicleService. Common;
using MyProject.WebApi.Models;

namespace MyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IVehicleMakeService vehicleMakeService;
        private readonly IVehicleModelService vehicleModelService;

        public VehicleModelController(IMapper mapper, IVehicleModelService vehicleModelService, IVehicleMakeService vehicleMakeService)
        {
            this.mapper = mapper;
            this.vehicleMakeService = vehicleMakeService;
            this.vehicleModelService = vehicleModelService;
        }

        // GET: api/VehicleModel
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] QueryParams queryParams)
        { 

            var filter = new Filter(queryParams.SearchBy, queryParams.Search);
            var sorting = new Sorting(queryParams.SortBy, queryParams.SortType);
            var paging = new Paging(queryParams.PageNumber, queryParams.PageSize);

            dynamic obj = new ExpandoObject();
            obj.VehicleModels = await vehicleModelService.GetAllModelsAsync(filter, paging, sorting);
            obj.Pagination = paging;
            obj.Filter = filter;
            obj.Sorting = sorting;

            return Ok(JsonSerializer.Serialize(obj));
        }

        // POST: api/VehicleModel
        [HttpPost]
        public async Task<HttpResponseMessage> PostAsync([FromQuery] QueryParams queryParams)
        {
            var vehicleModel = mapper.Map<IVehicleModelDTO>(queryParams);
            vehicleModel.VehicleMakeId = queryParams.VehicleMakeId;
            vehicleModel.Id = Guid.NewGuid();

            await vehicleModelService.AddVehicleModelAsync(vehicleModel);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // PUT: api/VehicleModel/5
        [HttpGet]
        [Route("Edit")]
        public async Task<IActionResult> GetEditAsync([FromQuery] Guid id)
        {
            var result = await vehicleModelService.GetVehicleModelAsync(id);

            return Ok(JsonSerializer.Serialize(result));
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<HttpResponseMessage> PutEditAsync([FromQuery] QueryParams queryParams)
        {
            var vehicleModel = mapper.Map<IVehicleModelDTO>(queryParams);

            await vehicleModelService.UpdateVehicleModelAsync(vehicleModel);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // DELETE: api/ApiWithActions/5
        [HttpGet]
        [Route("Delete")]
        public async Task<IActionResult> GetDeleteAsync(Guid id)
        {
            return Ok(JsonSerializer.Serialize(await vehicleModelService.GetVehicleModelAsync(id)));
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<HttpResponseMessage> DeleteAsync(Guid id)
        {
            await vehicleModelService.DeleteVehicleModelAsync(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}