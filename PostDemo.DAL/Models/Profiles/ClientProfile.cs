using AutoMapper;
using PostDemo.DAL.Models.DTOs;
using PostDemo.DAL.Models.Entities;

namespace PostDemo.DAL.Models.Profiles {
    public class ClientProfile : Profile {
        public ClientProfile() {
            CreateMap<Client, ClientDTO>();
            CreateMap<ClientDTO, Client>();
        }
    }
}
