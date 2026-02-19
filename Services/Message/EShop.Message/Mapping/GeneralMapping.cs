using AutoMapper;
using EShop.Message.DAL.Entities;
using EShop.Message.Dtos;

namespace EShop.Message.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping() 
        {
            CreateMap<UserMessage, ResultMessageDto>().ReverseMap();
            CreateMap<UserMessage, CreateMessageDto>().ReverseMap();
            CreateMap<UserMessage, ResultInboxMessageDto>().ReverseMap();
            CreateMap<UserMessage, ResultSandboxMessageDto>().ReverseMap();
            CreateMap<UserMessage, UpdateMessageDto>().ReverseMap();
            CreateMap<UserMessage, GetByIdMessageDto>().ReverseMap();
        }
    }
}
