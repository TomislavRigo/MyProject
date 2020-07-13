using MyProject.DTO.Common;

namespace MyProject.DTO
{
    public class Filter : IFilter
    {
        public Filter(string searchBy, string search)
        {
            SearchBy = searchBy ?? "Name"; 
            Search = search ?? "";
        }
        public string SearchBy { get; set; }
        public string Search { get; set; }
    }
}
