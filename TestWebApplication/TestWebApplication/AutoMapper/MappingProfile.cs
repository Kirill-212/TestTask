using AutoMapper;
using TestWebApplication.Dto;
using TestWebApplication.Models;

namespace TestWebApplication.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Img, ImgDto>();
            CreateMap<ImgDto, Img>();

            CreateMap<Comment, PostCommentDto>();
            CreateMap<PostCommentDto, Comment>();

            CreateMap<Comment, PutCommentDto>();
            CreateMap<PutCommentDto, Comment>();
        }
    }
}
