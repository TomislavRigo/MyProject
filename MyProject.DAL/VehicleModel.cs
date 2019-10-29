using System;

namespace MyProject.DAL
{
    public class VehicleModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public Guid VehicleMakeId { get; set; }
        public VehicleMake VehicleMake { get; set; }
    }
}
