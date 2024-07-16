using Microsoft.EntityFrameworkCore;
using NoticeBoard.Common.Enums;
using NoticeBoard.Repository.Db;
using NoticeBoard.Repository.Entities;
using NoticeBoard.Repository.Interfaces;
using NoticeBoard.Repository.Models.DataModels;
using NoticeBoard.Repository.Models.ParameterModels;

namespace NoticeBoard.Repository.Implements;

public class AnnouncementRepository(NoticeBoardDbContext noticeBoardDbContext) : IAnnouncementRepository
{
    /// <summary>
    /// 取得公告列表
    /// </summary>
    /// <param name="parameterModel"></param>
    /// <returns></returns>
    public async Task<IEnumerable<AnnouncementListDataModel>> GetListAsync(
        GetAnnouncementListParameterModel parameterModel)
    {
        var queryBuilder = noticeBoardDbContext.Announcements.AsQueryable();
        if (!string.IsNullOrEmpty(parameterModel.Title))
        {
            queryBuilder = queryBuilder.Where(x => x.Title.Contains(parameterModel.Title));
        }

        if (parameterModel.StartDate.HasValue)
        {
            queryBuilder = queryBuilder.Where(x => x.PublishStartDate >= parameterModel.StartDate);
        }

        if (parameterModel.EndDate.HasValue)
        {
            queryBuilder = queryBuilder.Where(x => x.PublishStartDate <= parameterModel.EndDate);
        }

        var dataModels = await queryBuilder.Select(x =>
            new AnnouncementListDataModel
            {
                Id = x.Id,
                AnnouncementType = x.AnnouncementType,
                Title = x.Title,
                PublishDate = x.PublishStartDate,
                PublishStatus = x.PublishStatus
            })
            .AsNoTracking()
            .ToListAsync();

        return dataModels;
    }


    /// <summary>
    /// 取得公告明細
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<AnnouncementDataModel?> GetDetailAsync(int id)
    {
        var dataModel = await noticeBoardDbContext.Announcements
            .Where(x => x.Id == id)
            .Select(x =>
                new AnnouncementDataModel
                {
                    Id = x.Id,
                    AnnouncementType = x.AnnouncementType,
                    Title = x.Title,
                    Content = x.Content,
                    PublishStartDate = x.PublishStartDate,
                    PublishEndDate = x.PublishEndDate,
                    PublishStatus = x.PublishStatus
                })
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return dataModel;
    }

    /// <summary>
    /// 取得公告
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Announcement?> GetAsync(int id)
    {
        var announcement = await noticeBoardDbContext.Announcements
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        return announcement;
    }

    /// <summary>
    /// 新增公告
    /// </summary>
    /// <param name="announcement"></param>
    /// <returns></returns>
    public async Task<bool> InsertAsync(Announcement announcement)
    {
        noticeBoardDbContext.Announcements.Add(announcement);
        var affectRow = await noticeBoardDbContext.SaveChangesAsync();
        return affectRow > 0;
    }
    
    /// <summary>
    /// 更新公告
    /// </summary>
    /// <param name="announcement"></param>
    /// <returns></returns>
    public async Task<bool> UpdateAsync(Announcement announcement)
    {
        noticeBoardDbContext.Announcements.Update(announcement);
        var affectRow = await noticeBoardDbContext.SaveChangesAsync();
        return affectRow > 0;
    }
}