using System;
using System.Collections.Generic;
using AluraFlix.Api.DTO;
using AluraFlix.Api.Business.Interfaces;

namespace AluraFlix.Api.Business.Rules
{
    public class VideoValidation : IVideoRules
    {
        private List<bool> validation = new List<bool>();
        public bool IsVideoValid(VideoDTO video)
        {
            AplyValidation(IsTituleValid(video));

            AplyValidation(IsDescriptionValid(video));

            AplyValidation(IsUrlVideoValid(video));

            return !validation.Contains(false);
        }

        private void AplyValidation(bool validation)
        {

            if (validation)
            {
                this.validation.Add(true);
            }
            else
            {
                this.validation.Add(false);
            }

        }

        private bool IsTituleValid(VideoDTO video)
        {
            return video.Titulo.Trim().Length > 0;
        }
        private bool IsDescriptionValid(VideoDTO video)
        {
            return video.Descricao.Trim().Length > 0;
        }
        private bool IsUrlVideoValid(VideoDTO video)
        {

           return this.UrlChecker(video.URL_Video);
        }


        private bool UrlChecker(string url)
        {
            Uri uriResult;
            bool tryCreateResult = Uri.TryCreate(url, UriKind.Absolute, out uriResult);
            if (tryCreateResult == true && uriResult != null)
                return true;
            else
                return false;
        }
    }
}