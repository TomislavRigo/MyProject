using MyProject.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.DTO
{
    public class Filter : IFilter
    {
        public string SearchBy {get; set;}
        public string Search { get; set; }
        public string SortBy { get; set; }
        public string SortType { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItemsCount { get; set; }
    }
}
