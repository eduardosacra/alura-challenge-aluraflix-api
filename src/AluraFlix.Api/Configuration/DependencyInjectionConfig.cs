using Microsoft.Extensions.DependencyInjection;
using AluraFlix.Api.Business.Interfaces;
using AluraFlix.Business.Interfaces;
using AluraFlix.Business.Services;
using AluraFlix.Api.Business.Rules;
using AluraFlix.Data;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        services.AddScoped<IVideoService, VideoService>();
        services.AddScoped<IVideoData, VideoData>();
        services.AddScoped<IVideoRules, VideoValidation>();
        return services;
    }
}