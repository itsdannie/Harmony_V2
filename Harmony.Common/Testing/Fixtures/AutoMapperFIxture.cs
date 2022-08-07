using AutoMapper;
using Harmony.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Common.Testing.Fixtures
{
    public static class AutoMapperFixture
    {
        public static IMapper CreateMapper()
        {
            AutoMapperProfile myProfile = new AutoMapperProfile();
            MapperConfiguration configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            IMapper mapper = new Mapper(configuration);
            return mapper;
        }
    }
}
