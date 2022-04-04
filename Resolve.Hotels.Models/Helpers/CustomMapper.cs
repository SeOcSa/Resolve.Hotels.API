using AutoMapper;
using Resolve.Hotels.Models.Enitities;
using Resolve.Hotels.Models.ViewModels;

namespace Resolve.Hotels.Models.Helpers
{
    public class CustomMapper<VM, E> where VM : IGenericViewModel where E: Entity
    {
       public E MapToEntity(VM viewModel)
       {
           var config = new MapperConfiguration(cfg =>
               cfg.CreateMap<VM, E>()
           );

           var mapper = new Mapper(config);

           return mapper.Map<E>(viewModel);
       }
       
       public VM MapToViewModel(E entity)
       {
           var config = new MapperConfiguration(cfg =>
               cfg.CreateMap<E, VM>()
           );

           var mapper = new Mapper(config);

           return mapper.Map<VM>(entity);
       }
    }
}