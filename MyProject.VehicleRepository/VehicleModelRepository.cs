using AutoMapper;
using MyProject.DAL;
using MyProject.DTO;
using MyProject.DTO.Common;
using MyProject.VehicleRepository.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.VehicleRepository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private readonly IGenericRepository genericRepository;
        private readonly IMapper mapper;

        public VehicleModelRepository(IGenericRepository genericRepository, IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }

        public async Task<IVehicleModelModel> GetAllModelsAsync()
        {
            var result = await genericRepository.GetAllModelsAsync<VehicleModel>();
            var vehicleMakeList = new VehicleModelModel()
            {
                VehicleModels = result
            };
            return vehicleMakeList;
        }
        public async Task<IVehicleModelModel> GetVehicleModelAsync(Guid id)
        {
            return mapper.Map<IVehicleModelModel>(await genericRepository.GetAsync<VehicleModel>(id));
        }

        public async Task<int> AddVehicleModelAsync(IVehicleModelModel vehicleModel)
        {
            var model = mapper.Map<VehicleModel>(vehicleModel);
            return await genericRepository.AddAsync(model);
        }

        public async Task<int> UpdateVehicleModelAsync(IVehicleModelModel vehicleModel)
        {
            var model = mapper.Map<VehicleModel>(vehicleModel);
            return await genericRepository.UpdateAsync(model);
        }

        public async Task<int> DeleteVehicleModelAsync(IVehicleModelModel vehicleModel)
        {
            var model = mapper.Map<VehicleModel>(vehicleModel);
            return await genericRepository.DeleteAsync(model);
        }
    }
}
