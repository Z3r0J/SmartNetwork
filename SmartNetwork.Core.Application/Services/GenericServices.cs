using AutoMapper;
using SmartNetwork.Core.Application.Interfaces.Repository;
using SmartNetwork.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNetwork.Core.Application.Services
{
    public class GenericServices<SaveViewModel,ViewModel,Entity> : IGenericServices<SaveViewModel,ViewModel,Entity>
        where SaveViewModel : class
        where ViewModel : class
        where Entity : class
    {
        private readonly IGenericRepository<Entity> _repository;

        private readonly IMapper _mapper;
        public GenericServices(IGenericRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async virtual Task<SaveViewModel> Add(SaveViewModel vm) {

            Entity entity = _mapper.Map<Entity>(vm);

            entity = await _repository.AddAsync(entity);

            SaveViewModel SaveVm = _mapper.Map<SaveViewModel>(entity);

            return SaveVm;
        
        }

        public async virtual Task<SaveViewModel> GetByIdSaveViewModel(int id) {

            Entity entity = await _repository.GetByIdAsync(id);

            SaveViewModel SaveVM = _mapper.Map<SaveViewModel>(entity);

            return SaveVM;
        
        }

        public async virtual Task<List<ViewModel>> GetAllViewModel() {

            var entityList = await _repository.GetAllAsync();

            return _mapper.Map<List<ViewModel>>(entityList);
        }

        public async virtual Task Update(SaveViewModel vm, int id) {

            Entity entity = _mapper.Map<Entity>(vm);

            await _repository.UpdateAsync(entity, id);

        }

        public async virtual Task Delete(int id) {

            Entity entity = await _repository.GetByIdAsync(id);

            await _repository.DeleteAsync(entity);
        
        }
    }
}
