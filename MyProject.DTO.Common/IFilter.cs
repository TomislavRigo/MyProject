using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.DTO.Common
{
    public interface IFilter
    {
        string SearchBy { get; set; }
        string Search { get; set; }
        string SortBy { get; set; }
        string SortType { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }
        int TotalItemsCount { get; set; }

    }
}
