﻿using MyProject.DAL;
using MyProject.DTO.Common;
using System;
using System.Collections.Generic;

namespace MyProject.MVC.Models
{
    public class VehicleModelViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public VehicleMake VehicleMake { get; set; }
        public IEnumerable<IVehicleModelDTO> VehicleModels {get; set;}
        public Guid VehicleMakeId { get; set; }
    }
}
