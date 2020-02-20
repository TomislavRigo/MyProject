using MyProject.DAL;
using System;
using System.Collections.Generic;

namespace MyProject.DTO.Common
{
    public interface IVehicleModelModel
    {
        Guid Id { get; set; }
        Guid VehicleMakeId { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
        IVehicleMakeModel VehicleMake { get; set; }
        IEnumerable<VehicleModel> VehicleModels { get; set; }
        int TotalItemsCount { get; set; }
        string Make { get; set; }
    }
}
