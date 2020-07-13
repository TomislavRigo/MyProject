using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
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
        public async Task<string> GetAsync([FromQuery] QueryParams queryParams)
        {
            var filter = new Filter(queryParams.SearchBy, queryParams.Search);
            var sorting = new Sorting(queryParams.SortBy, queryParams.SortType);
            var paging = new Paging(queryParams.PageNumber, queryParams.PageSize);

            dynamic obj = new ExpandoObject();
            obj.VehicleMakes = await vehicleMakeService.GetAllMakesAsync(filter, paging, sorting);
            obj.Pagination = paging;
            obj.Filter = filter;
            obj.Sorting = sorting;

            return JsonSerializer.Serialize(obj);
        }

        // POST: api/VehicleMake
        [HttpPost]
        public async Task PostAsync([FromQuery] QueryParams queryParams)
        {
            var vehicleMake = mapper.Map<VehicleMakeDTO>(queryParams);
            vehicleMake.Id = Guid.NewGuid();

            await vehicleMakeService.AddVehicleMakeAsync(vehicleMake);
        }

        // PUT: api/VehicleMake/5
        [HttpPut]
        public async Task PutAsync([FromQuery] QueryParams queryParams)
        {
            var vehicleMake = new VehicleMakeDTO()
            {
                Id = queryParams.Id,
                Name = queryParams.Name,
                Abrv = queryParams.Abrv
            };

            await vehicleMakeService.UpdateVehicleMakeAsync(vehicleMake);
        }

        // DELETE: api/ApiWithActions/5
        [HttpGet]
        [Route("{id}")]
        public async Task<string> GetDeleteAsync(Guid id)
        {
            return JsonSerializer.Serialize(await vehicleMakeService.GetVehicleMakeAsync(id));
        }

        [HttpPost]
        [Route("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await vehicleMakeService.DeleteVehicleMakeAsync(id);
        }
    }
}