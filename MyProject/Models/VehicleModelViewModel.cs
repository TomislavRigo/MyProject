using MyProject.DAL;
using MyProject.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.MVC.Models
{
    public class VehicleModelViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public VehicleMake VehicleMake { get; set; }
        public IEnumerable<IVehicleModelModel> VehicleModels {get; set;}
        public Guid VehicleMakeId { get; set; }
        public string Make { get; set; }
    }
}
