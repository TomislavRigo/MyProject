using MyProject.DAL;
using System;
using System.Collections.Generic;

namespace MyProject.DTO.Common
{
    public interface IVehicleMakeModel
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
        IEnumerable<VehicleMake> VehicleMakes { get; set; }
        List<VehicleModel> VehicleModels { get; set; }
    }
}
