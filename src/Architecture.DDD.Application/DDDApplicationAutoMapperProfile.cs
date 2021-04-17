using Architecture.DDD.Infra;
using AutoMapper;

namespace Architecture.DDD
{
    public class DDDApplicationAutoMapperProfile : Profile
    {
        public DDDApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Device, DeviceDto>();
        }
    }
}
