namespace MyProject.DTO.Common
{
    public interface IFilter
    {
        string SearchBy { get; set; }
        string Search { get; set; }
        string SortBy { get; set; }
        string SortType { get; set; }
    }
}
