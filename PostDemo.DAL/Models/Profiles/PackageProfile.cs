using AutoMapper;
using PostDemo.DAL.Models.DTOs;
using PostDemo.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostDemo.DAL.Models.Profiles {
    public class PackageProfile : Profile {
        public PackageProfile() {
            CreateMap<PackageDTO, Package>();
            CreateMap<Package, PackageDTO>();
        }
    }
}
