using MyProject.DAL;
using MyProject.DTO.Common;
using System;
using System.Collections.Generic;

namespace MyProject.DTO
{
    public class VehicleModelDTO : IVehicleModelDTO
    {
        public Guid Id { get; set; }

        public Guid VehicleMakeId { get; set; }

        public string Name { get; set; }

        public string Abrv { get; set; }

        public IVehicleMakeDTO VehicleMake { get; set; }
    }
}
