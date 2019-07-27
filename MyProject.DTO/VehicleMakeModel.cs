using MyProject.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.DTO
{
    public class VehicleMakeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public List<VehicleModel> VehicleModels { get; set; }
    }
}
