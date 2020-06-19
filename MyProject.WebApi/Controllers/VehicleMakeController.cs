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
            var filter = new Filter(queryParams.SearchBy, queryParams.Search, queryParams.SortBy, queryParams.SortType);
            var paging = new Paging(queryParams.PageNumber, queryParams.PageSize);

            var result = await vehicleMakeService.GetAllMakesAsync(filter, paging);

            var vehicleMakes = (IEnumerable<IVehicleMakeDTO>)result["makes"];
            var pagination = (IPaging)result["paging"];

            dynamic obj = new ExpandoObject();
            obj.VehicleMakes = vehicleMakes;
            obj.Pagination = pagination;
            obj.Filter = filter;

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
        [HttpDelete]
        public async Task DeleteAsync([FromQuery] QueryParams queryParams)
        {
            var vehicleMake = new VehicleMakeDTO()
            {
                Id = queryParams.Id,
                Name = queryParams.Name,
                Abrv = queryParams.Abrv
            };

            await vehicleMakeService.DeleteVehicleMakeAsync(vehicleMake);
        }
    }
}