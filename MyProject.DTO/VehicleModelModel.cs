using MyProject.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.DTO
{
    class VehicleModelModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public VehicleMake VehicleMake { get; set; }
        public int TotalItemsCount { get; set; }
    }
}
