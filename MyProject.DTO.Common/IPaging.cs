using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.DTO.Common
{
    public interface IPaging
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
        int Skip { get; set; }
        int TotalItemsCount { get; set; }
    }
}
