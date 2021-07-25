using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AluraFlix.Api.DTO;
using AluraFlix.Business.Models;

namespace AluraFlix.Business.Interfaces
{
    public interface IVideoData
    {
        Task<IEnumerable<Video>> GetVideos();
        Task<Video> GetVideo(int Id);
        Task<Video> SaveVideo(Video video);
        Task Update(Video video);
        Task Delete(int ID);
    }
}