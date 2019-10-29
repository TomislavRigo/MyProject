using MyProject.DAL;
using MyProject.DTO.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.MVC.Models
{
    public class VehicleMakeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public IEnumerable<IVehicleMakeModel> VehicleMakes { get; set; }
    }
}
