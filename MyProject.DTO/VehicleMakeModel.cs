using MyProject.DAL;
using MyProject.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.DTO
{
    public class VehicleMakeModel : IVehicleMakeModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public IEnumerable<VehicleMake> VehicleMakes { get; set; }
        public List<VehicleModel> VehicleModels { get; set; }
    }
}
