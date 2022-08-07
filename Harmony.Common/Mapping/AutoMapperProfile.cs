using AutoMapper;

namespace Harmony.Common.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            var mapFromType = typeof(IMapFrom<>);
            var mapToType = typeof(IMapTo<>);
            var haveCustomMappingType = typeof(IHaveCustomMapping);

            var modelRegistrations = AppDomain
                .CurrentDomain
                .GetAssemblies()
                .Where(a => a.GetName().Name.StartsWith("Harmony"))
                .SelectMany(a => a.GetExportedTypes())
                .Where(t => t.IsClass && !t.IsAbstract)
                .Select(t => new
                {
                    Type = t,
                    MapFrom = this.GetMappingProfile(t, mapFromType),
                    MapTo = this.GetMappingProfile(t, mapToType),
                    ExplicitMap = t.GetInterfaces()
                        .Where(i => i == haveCustomMappingType)
                        .Select(i => (IHaveCustomMapping)Activator.CreateInstance(t))
                        .FirstOrDefault()
                });

            foreach (var modelRegistration in modelRegistrations)
            {
                if (modelRegistration.MapFrom != null)
                {
                    this.CreateMap(modelRegistration.MapFrom, modelRegistration.Type);
                }

                if (modelRegistration.MapTo != null)
                {
                    this.CreateMap(modelRegistration.Type, modelRegistration.MapTo);
                }

                modelRegistration.ExplicitMap?.ConfigureMapping(this);
            }
        }

        private Type GetMappingProfile(Type type, Type mappingInterface)
          => type.GetInterfaces()
              .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == mappingInterface)
              ?.GetGenericArguments()
              .First();
    }
}
