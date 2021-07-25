using System.Collections.Generic;
using System.Threading.Tasks;
using AluraFlix.Api.DTO;
using AluraFlix.Business.Models;

namespace AluraFlix.Business.Interfaces
{
    public interface IVideoService
    {
        Task<IEnumerable<Video>> GetVideos();
        Task<Video> GetVideo(int Id);
        Task<VideoDTO> SalvarVideo(VideoDTO video);
        Task UpdateVideo(VideoDTO video);
        Task DeleteVideo(int id);
    }
}