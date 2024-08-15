using AutoMapper;
using OllieShop.Message.Dal.Entitites;
using OllieShop.Message.Dtos;

namespace OllieShop.Message.MappingProfiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            // Entity -> DTO mapping
            CreateMap<Dal.Entitites.Message, ResultMessageDto>();
            CreateMap<Dal.Entitites.Message, ResultInboxMessageDto>();
            CreateMap<Dal.Entitites.Message, ResultSendBoxMessageDto>();
            CreateMap<Dal.Entitites.Message, GetByIdMessageDto>();

            // DTO -> Entity mapping
            CreateMap<CreateMessageDto, Dal.Entitites.Message>();
            CreateMap<UpdateMessageDto, Dal.Entitites.Message>();
        }
    }
}
