using NoticeBoard.Repository.Implements;
using NoticeBoard.Repository.Interfaces;
using NoticeBoard.Service.Implements;
using NoticeBoard.Service.Interfaces;

namespace NoticeBoard.WebApplication.Infrastructures.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddNoticeBoardServices(this IServiceCollection services)
    {
        services.AddScoped<IAnnouncementService, AnnouncementService>();
        services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
    }
}