using AluraFlix.Api.DTO;

namespace AluraFlix.Api.Business.Interfaces
{
    public interface IVideoRules
    {
        bool IsVideoValid(VideoDTO video);
    }
}