using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.DTO.Common
{
    public interface ISorting
    {
        string SortBy { get; set; }
        string SortType { get; set; }
    }
}
