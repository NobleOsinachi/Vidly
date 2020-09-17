using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    //This profile determines how objects of diff types can be mapped to each other
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            /*Domain to Dto*/
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();


            /*Dto to Domain*/
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MembershipTypeDto, MembershipType>();
            Mapper.CreateMap<GenreDto, Genre>();

        }
    }
}