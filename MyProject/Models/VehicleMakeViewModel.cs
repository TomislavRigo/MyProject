using MyProject.DTO.Common;
using System;
using System.Collections.Generic;

namespace MyProject.MVC.Models
{
    public class VehicleMakeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
