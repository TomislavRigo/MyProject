﻿using System;
using System.Collections.Generic;

namespace MyProject.DAL
{
    public class VehicleMake
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public List<VehicleModel> VehicleModels { get; set; }
    }
}
