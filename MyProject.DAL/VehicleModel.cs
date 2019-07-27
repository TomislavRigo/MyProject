using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.DAL
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public VehicleMake VehicleMake { get; set; }
    }
}
