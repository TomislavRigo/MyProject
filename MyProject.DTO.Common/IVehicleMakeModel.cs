using System;
using System.Collections.Generic;

namespace MyProject.DTO.Common
{
    public interface IVehicleMakeModel
    {
        int Id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
        Guid VehicleMakeId { get; set; }
        List<IVehicleModelModel> VehicleModels { get; set; }
    }
}
