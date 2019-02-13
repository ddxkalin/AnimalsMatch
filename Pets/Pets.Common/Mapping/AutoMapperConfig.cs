namespace Pets.Common.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using AutoMapper;

    public static class AutoMapperConfig
    {
        public static void RegisterMappings(params Assembly[] assemblies)
        {
            List<Type> types = assemblies.SelectMany(a => a.GetExportedTypes()).ToList();

            Mapper.Initialize(
                configuration =>
                {
                    AutoMapperConfig.RegisterStandardFromMappings(configuration, types);

                    AutoMapperConfig.RegisterCustomMaps(configuration, types);
                });
        }

        private static void RegisterStandardFromMappings(IProfileExpression configuration, IEnumerable<Type> types)
        {
            IEnumerable<TypesMap> maps = AutoMapperConfig.GetFromMaps(types);

            AutoMapperConfig.CreateMappings(configuration, maps);
        }

        private static void RegisterCustomMaps(IMapperConfigurationExpression configuration, IEnumerable<Type> types)
        {
            IEnumerable<IHaveCustomMappings> maps = AutoMapperConfig.GetCustomMappings(types);

            AutoMapperConfig.CreateMappings(configuration, maps);
        }

        private static IEnumerable<IHaveCustomMappings> GetCustomMappings(IEnumerable<Type> types)
        {
            IEnumerable<IHaveCustomMappings> customMaps = from t in types
                                                          from i in t.GetTypeInfo().GetInterfaces()
                                                          where typeof(IHaveCustomMappings).GetTypeInfo().IsAssignableFrom(t) &&
                                                              !t.GetTypeInfo().IsAbstract &&
                                                              !t.GetTypeInfo().IsInterface
                                                          select (IHaveCustomMappings)Activator.CreateInstance(t);

            return customMaps;
        }

        private static IEnumerable<TypesMap> GetFromMaps(IEnumerable<Type> types)
        {
            IEnumerable<TypesMap> fromMaps = from t in types
                from i in t.GetTypeInfo().GetInterfaces()
                where i.GetTypeInfo().IsGenericType &&
                      (i.GetGenericTypeDefinition() == typeof(IMapFrom<>)) &&
                      !t.GetTypeInfo().IsAbstract &&
                      !t.GetTypeInfo().IsInterface
                select new TypesMap
                {
                    Source = i.GetTypeInfo().GetGenericArguments()[0],
                    Destination = t
                };

            return fromMaps;
        }

        private static void CreateMappings(IProfileExpression configuration, IEnumerable<TypesMap> maps)
        {
            foreach (TypesMap map in maps)
            {
                configuration.CreateMap(map.Source, map.Destination).ReverseMap();
            }
        }

        private static void CreateMappings(IMapperConfigurationExpression configuration, IEnumerable<IHaveCustomMappings> maps)
        {
            foreach (IHaveCustomMappings map in maps)
            {
                map.CreateMappings(configuration);
            }
        }
    }
}