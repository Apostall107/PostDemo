using AutoMapper;
using PostDemo.DAL.Models.DTOs;
using PostDemo.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostDemo.DAL.Models.Profiles {
    internal class ClientProfile : Profile {
        public ClientProfile() {
            CreateMap<Client, ClientDTO>();
            CreateMap<ClientDTO, Client>();
        }
    }
}
