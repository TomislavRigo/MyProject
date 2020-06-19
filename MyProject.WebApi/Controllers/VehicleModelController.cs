﻿using System;
using System.Collections.Generic;
using System.Dynamic;
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
        public async Task<string> GetAsync([FromQuery] QueryParams queryParams)
        { 

            var filter = new Filter(queryParams.SearchBy, queryParams.Search, queryParams.SortBy, queryParams.SortType);
            var paging = new Paging(queryParams.PageNumber, queryParams.PageSize);

            var result = await vehicleModelService.GetAllModelsAsync(filter, paging);

            var vehicleModels = (IEnumerable<IVehicleModelDTO>)result["models"];
            var pagination = (IPaging)result["paging"];

            dynamic obj = new ExpandoObject();
            obj.VehicleMakes = vehicleModels;
            obj.Pagination = paging;
            obj.Filter = filter;

            return JsonSerializer.Serialize(obj);
        }

        // POST: api/VehicleModel
        [HttpPost]
        public async Task PostAsync([FromQuery] QueryParams queryParams)
        {
            IVehicleModelDTO vehicleModel = new VehicleModelDTO()
            {
                Id = Guid.NewGuid(),
                VehicleMakeId = queryParams.Id,
                Name = queryParams.Name,
                Abrv = queryParams.Abrv,
                VehicleMake = await vehicleMakeService.GetVehicleMakeAsync(queryParams.Id)
            };
            await vehicleModelService.AddVehicleModelAsync(vehicleModel);
        }

        // PUT: api/VehicleModel/5
        [HttpPut]
        public async Task Put([FromQuery] QueryParams queryParams)
        {
            var vehicleModel = new VehicleModelDTO()
            {
                Id = queryParams.Id,
                Name = queryParams.Name,
                Abrv = queryParams.Abrv
            };

            await vehicleModelService.UpdateVehicleModelAsync(vehicleModel);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public async Task DeleteAsync([FromQuery] QueryParams queryParams)
        {
            var vehicleModel = await vehicleModelService.GetVehicleModelAsync(queryParams.Id);

            await vehicleModelService.DeleteVehicleModelAsync(vehicleModel);
        }
    }
}