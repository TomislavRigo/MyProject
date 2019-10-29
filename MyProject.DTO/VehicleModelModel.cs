using MyProject.DAL;
using MyProject.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.DTO
{
    public class VehicleModelModel : IVehicleModelModel
    {
        public Guid Id { get; set; }
        public Guid VehicleMakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public IVehicleMakeModel VehicleMake { get; set; }
        public IEnumerable<VehicleModel> VehicleModels { get; set; }
        public int TotalItemsCount { get; set; }
    }
}
