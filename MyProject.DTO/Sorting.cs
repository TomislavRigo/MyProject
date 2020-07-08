using MyProject.DTO.Common;

namespace MyProject.DTO
{
    public class Sorting : ISorting
    {
        public Sorting(string sortBy, string sortType)
        {
            SortBy = sortBy ?? "Name";
            SortType = sortType ?? "asc";
        }
        public string SortBy { get; set; }
        public string SortType { get; set; }
    }
}
