using MyProject.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.DTO
{
    public class Paging : IPaging
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Skip
        {
            get
            {
                return (PageNumber - 1) * PageSize;
            }
            set { }
        }
        public int TotalItemsCount { get; set; }
    }
}
