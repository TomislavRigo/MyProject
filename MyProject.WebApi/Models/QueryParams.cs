using System;

namespace MyProject.WebApi.Models
{
    public class QueryParams
    {
            public Guid Id { get; set; }
            public Guid VehicleMakeId { get; set; }
            public string Name { get; set; }
            public string Abrv { get; set; }
            public string SearchBy { get; set; }
            public string Search { get; set; }
            public string SortBy { get; set; }
            public string SortType { get; set; }
            public int? PageNumber { get; set; }
            public int? PageSize { get; set; }
    }
}
