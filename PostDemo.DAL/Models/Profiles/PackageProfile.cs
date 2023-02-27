using AutoMapper;
using PostDemo.DAL.Models.DTOs;
using PostDemo.DAL.Models.Entities;

namespace PostDemo.DAL.Models.Profiles {
    public class PackageProfile : Profile {
        public PackageProfile() {
            CreateMap<PackageDTO, Package>();
            CreateMap<Package, PackageDTO>();
        }
    }
}
