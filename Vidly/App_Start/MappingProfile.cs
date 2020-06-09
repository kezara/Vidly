using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<MembershipType, MembershipTypeDTO>();
            Mapper.CreateMap<Genre, GenreDTO>();

            //DTO to Domain
            Mapper.CreateMap<CustomerDTO, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDTO, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}