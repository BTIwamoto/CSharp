using AutoMapper;
using NerdStore.Catalogo.Application.Interfaces.AppServices;
using NerdStore.Catalogo.Application.ViewModels;
using NerdStore.Core.Data;
using NerdStore.Core.DomainObjects.Entities;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Application.Services.AppServices
{
    public class AppService<T, TR> : IAppService<T> where T : ViewModel where TR : Entity
    {
        private readonly IMapper _mapper;

        private readonly IRepository<TR> _repository;

        protected AppService(IMapper mapper, IRepository<TR> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task Adicionar(T objectViewModel)
        {
            var obj = _mapper.Map<TR>(typeof(T));

            _repository.Adicionar(obj);

            await _repository.UnitOfWkOfWork.Commit();
        }

        public async Task Atualizar(T objectViewModel)
        {
            var obj = _mapper.Map<TR>(typeof(T));

            _repository.Atualizar(obj);

            await _repository.UnitOfWkOfWork.Commit();
        }
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}