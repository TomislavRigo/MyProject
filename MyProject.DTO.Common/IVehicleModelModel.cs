namespace MyProject.DTO.Common
{
    public interface IVehicleModelModel
    {
        int Id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
        IVehicleMakeModel VehicleMake { get; set; }
        int TotalItemsCount { get; set; }
    }
}
