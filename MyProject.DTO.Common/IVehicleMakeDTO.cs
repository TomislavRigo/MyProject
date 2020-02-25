using MyProject.DAL;
using System;
using System.Collections.Generic;

namespace MyProject.DTO.Common
{
    public interface IVehicleMakeDTO
    {
        Guid Id { get; set; }

        string Name { get; set; }

        string Abrv { get; set; }

        List<VehicleModel> VehicleModels { get; set; }
    }
}
