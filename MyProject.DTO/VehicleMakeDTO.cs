using MyProject.DAL;
using MyProject.DTO.Common;
using System;
using System.Collections.Generic;

namespace MyProject.DTO
{
    public class VehicleMakeDTO : IVehicleMakeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public List<VehicleModel> VehicleModels { get; set; }
    }
}
