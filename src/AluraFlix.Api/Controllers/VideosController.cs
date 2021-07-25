using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AluraFlix.Api.DTO;
using AluraFlix.Business.Interfaces;

namespace AluraFlix.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class VideosController : ControllerBase
    {
        private readonly IVideoService _videoService;

        public VideosController(IVideoService videoService)
        {
            _videoService = videoService;
        }
        /// <summary>
        /// Consulta os videos disponveis.
        /// </summary>
        /// <returns></returns>
        [HttpGet("videos")]
        public async Task<ActionResult> videosAsync() {

            try {
                var videos = await this._videoService.GetVideos();

                if(videos == null )
                    return BadRequest();

                return Ok(videos);
            }catch(Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Consulta um video específico por ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("videos/{Id:int}")]
        public async Task<ActionResult> VideoAsync(int Id)
        {
            try{
                var video = await this._videoService.GetVideo(Id);

                if(video == null)
                    return BadRequest();

                return Ok(video);

            }catch(Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Cadastra no um novo Video
        /// </summary>
        /// <param name="video"></param>
        /// <returns></returns>
        [HttpPost("videos")]
        public async Task<ActionResult> VideoPost(VideoDTO video)
        {
            try {
                var resultado =  await this._videoService.SalvarVideo(video);
                if(resultado == null)
                    return BadRequest();

                return CreatedAtAction("videos", resultado);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualiza um vide existente.
        /// </summary>
        /// <param name="video"></param>
        /// <returns></returns>
        [HttpPut("videos")]
        public async Task<ActionResult> VideoUpdate(VideoDTO video)
        {
            try {
                await this._videoService.UpdateVideo(video);
                return NoContent();
            } catch(Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Deleta um video existente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("videos/{Id:int}")]
        public async Task<ActionResult> VideoDelete(int id)
        {
            try {
                await this._videoService.DeleteVideo(id);

                return Ok();

            }catch(Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}