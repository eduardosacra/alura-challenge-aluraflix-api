using System.Threading;
using System.Data;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using AluraFlix.Business.Interfaces;
using AluraFlix.Business.Models;
using Dapper;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using AluraFlix.Api.DTO;
using Dapper.Contrib.Extensions;

namespace AluraFlix.Data
{
    public class VideoData : IVideoData
    {
        private readonly IConfiguration _configuration;

        public VideoData(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Delete(int id)
        {
            using(SqlConnection conexao = new SqlConnection(
                this._configuration.GetConnectionString("ConnectionAluraFlix")
            )) {
                await conexao.ExecuteAsync("Delete from Video where Id = @Id",
                new {Id = id}, commandType: CommandType.Text).ConfigureAwait(false);
            }
        }

        public async Task<Video> GetVideo(int Id)
        {
            using (SqlConnection conexao = new SqlConnection(
                this._configuration.GetConnectionString("ConnectionAluraFlix")
            ))
            {
                return await conexao.QueryFirstOrDefaultAsync<Video>(
                    @"SELECT [Id]
                            ,[Titulo]
                            ,[Descricao]
                            ,[URL_Video]
                        FROM [dbo].[Video]
                        WHERE
                            Id = @Id",
                    new { Id = Id },
                    commandType: CommandType.Text
                ).ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<Video>> GetVideos()
        {
            using (SqlConnection con = new SqlConnection(
                this._configuration.GetConnectionString("ConnectionAluraFlix")))
            {
                return await con.QueryAsync<Video>("CONSULTAR_VIDEOS", commandType: CommandType.StoredProcedure);

            }
        }

        public async Task<Video> SaveVideo(Video video)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(
                    this._configuration.GetConnectionString("ConnectionAluraFlix")
                ))
                {

                    return await conexao.QueryFirstAsync<Video>("PRC_INSERT_VIDEO", 
                    new {
                        Titulo = video.Titulo,
                        Descricao = video.Descricao,
                        URL_Video = video.URL_Video
                    },
                    commandType : CommandType.StoredProcedure).ConfigureAwait(false);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task Update(Video video)
        {
            using(SqlConnection conexao = new SqlConnection(
                this._configuration.GetConnectionString("ConnectionAluraFlix")
            )) {
                await conexao.ExecuteAsync(" Update Video set Titulo = @Titulo, Descricao = @Descricao, URL_Video = @Url_Video where Id = @Id",
                new {Titulo = video.Titulo, Descricao = video.Descricao, Url_Video = video.URL_Video, Id = video.Id}, 
                commandType: CommandType.Text).ConfigureAwait(false);
            }
        }
    }
}
