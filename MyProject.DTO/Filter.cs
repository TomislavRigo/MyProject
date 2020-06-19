using MyProject.DTO.Common;

namespace MyProject.DTO
{
    public class Filter : IFilter
    {
        public Filter(string searchBy, string search, string sortBy, string sortType)
        {
            SearchBy = searchBy ?? "Name"; 
            Search = search ?? "";
            SortBy = sortBy ?? "Name";
            SortType = sortType ?? "asc";
        }
        public string SearchBy { get; set; }
        public string Search { get; set; }
        public string SortBy { get; set; }
        public string SortType { get; set; }
    }
}
