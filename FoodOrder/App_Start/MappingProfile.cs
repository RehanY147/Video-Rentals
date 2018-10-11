using AutoMapper;
using FoodOrder.Dtos;
using FoodOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodOrder.App_Start {
    public class MappingProfile: Profile {
        public MappingProfile() {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>().ForMember(c => c.Id, opt => opt.Ignore());

        }
    }
}