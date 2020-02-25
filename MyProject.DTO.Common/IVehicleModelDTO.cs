using MyProject.DAL;
using System;
using System.Collections.Generic;

namespace MyProject.DTO.Common
{
    public interface IVehicleModelDTO
    {
        Guid Id { get; set; }

        Guid VehicleMakeId { get; set; }

        string Name { get; set; }

        string Abrv { get; set; }

        IVehicleMakeDTO VehicleMake { get; set; }
    }
}
