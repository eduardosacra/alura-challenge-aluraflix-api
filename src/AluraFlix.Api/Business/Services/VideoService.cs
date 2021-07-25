using System.Collections.Generic;
using System.Threading.Tasks;
using AluraFlix.Api.DTO;
using AluraFlix.Api.Business.Interfaces;
using AluraFlix.Business.Interfaces;
using AluraFlix.Business.Models;

namespace AluraFlix.Business.Services
{
    public class VideoService : IVideoService
    {
        private readonly IVideoData  _videoData;
        private readonly IVideoRules _videoRules;

        public VideoService(
            IVideoData videoData,
            IVideoRules videoRules)
        {
            this._videoData = videoData;
            this._videoRules = videoRules;
        }
        public async Task<IEnumerable<Video>> GetVideos()
        {   var videos = await this._videoData.GetVideos();
            return videos;
        }
        public async Task<Video> GetVideo(int Id)
        {
            var video = await this._videoData.GetVideo(Id);
            return video;
        }

        public async Task<VideoDTO> SalvarVideo(VideoDTO video)
        {
            var videoInsert = this.VideoDtoToVideo(video);

            if(this._videoRules.IsVideoValid(video)) {
                var videoNew = await this._videoData.SaveVideo(videoInsert);
                return new VideoDTO(){
                    Id = videoNew.Id,
                    Titulo = videoNew.Titulo,
                    Descricao = videoNew.Descricao,
                    URL_Video = videoNew.URL_Video
                };
            }
            else
            {
                return null;
            }
        }

        public async Task UpdateVideo(VideoDTO videoDto)
        {
            if(this._videoRules.IsVideoValid(videoDto)) {
                var video = this.VideoDtoToVideo(videoDto);
                await this._videoData.Update(video);
            }
            else
            {
                throw new System.Exception("Video Inválido");
            }
        }

        public async Task DeleteVideo(int id)
        {
            await this._videoData.Delete(id);
        }

        private Video VideoDtoToVideo (VideoDTO videoDTO) =>
            new Video()
            {
                Id = videoDTO.Id ?? 0,
                Titulo = videoDTO.Titulo,
                Descricao = videoDTO.Descricao,
                URL_Video = videoDTO.URL_Video
            };
    }
}