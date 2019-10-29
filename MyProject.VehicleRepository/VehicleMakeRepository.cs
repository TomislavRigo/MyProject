using AutoMapper;
using MyProject.DAL;
using MyProject.DTO;
using MyProject.DTO.Common;
using MyProject.VehicleRepository.Common;
using System;
using System.Threading.Tasks;

namespace MyProject.VehicleRepository
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        private readonly IGenericRepository genericRepository;
        private readonly IMapper mapper;

        public VehicleMakeRepository(IGenericRepository genericRepository, IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }

        public async Task<IVehicleMakeModel> GetAllMakesAsync()
        {
            var result = await genericRepository.GetAllModelsAsync<VehicleMake>();
            //var vehicleMakeList = new VehicleMakeModel();
            //vehicleMakeList.VehicleMakes = result;
            var vehicleMakeList = new VehicleMakeModel()
            {
                VehicleMakes = result
            };
            return vehicleMakeList;
        }

        public async Task<IVehicleMakeModel> GetVehicleMakesAsync(Guid id)
        {
            var result = await genericRepository.GetAsync<VehicleMake>(id);
            return mapper.Map<IVehicleMakeModel>(result);
        }

        public async Task<int> AddVehicleMakeAsync(IVehicleMakeModel vehicleMake)
        {
            var vehicle = mapper.Map<VehicleMake>(vehicleMake);
            return await genericRepository.AddAsync(vehicle);
        }

        public async Task<int> UpdateVehicleMakeAsync(IVehicleMakeModel vehicleMake)
        {
            var vehicle = mapper.Map<VehicleMake>(vehicleMake);
            return await genericRepository.UpdateAsync(vehicle);
        }

        public async Task<int> DeleteVehicleMakeAsync(IVehicleMakeModel vehicleMake)
        {
            var vehicle = mapper.Map<VehicleMake>(vehicleMake);
            return await genericRepository.DeleteAsync(vehicle);
        }
    }
}
