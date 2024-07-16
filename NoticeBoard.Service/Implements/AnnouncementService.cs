using NoticeBoard.Repository.Entities;
using NoticeBoard.Repository.Interfaces;
using NoticeBoard.Repository.Models.ParameterModels;
using NoticeBoard.Service.Interfaces;
using NoticeBoard.Service.Models.ParameterDtos;
using NoticeBoard.Service.Models.ResultDtos;

namespace NoticeBoard.Service.Implements;

public class AnnouncementService(IAnnouncementRepository announcementRepository) : IAnnouncementService
{
    /// <summary>
    /// 取得公告列表
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns></returns>
    public async Task<IEnumerable<AnnouncementListResultDto>> GetListAsync(GetAnnouncementListParameterDto parameter)
    {
        var announcementDataModels =
            await announcementRepository.GetListAsync(new GetAnnouncementListParameterModel
            {
                StartDate = parameter.StartDate,
                EndDate = parameter.EndDate,
                Title = parameter.Title
            });

        var resultDtos = announcementDataModels.Select(x =>
            new AnnouncementListResultDto
            {
                Id = x.Id,
                AnnouncementType = x.AnnouncementType,
                Title = x.Title,
                PublishDate = x.PublishDate,
                PublishStatus = x.PublishStatus
            });

        return resultDtos;
    }

    /// <summary>
    /// 取得公告明細
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<AnnouncementResultDto?> GetAsync(int id)
    {
        var announcementDataModel = await announcementRepository.GetDetailAsync(id);
        if (announcementDataModel is null)
        {
            return null;
        }

        var resultDto = new AnnouncementResultDto
        {
            Id = announcementDataModel.Id,
            AnnouncementType = announcementDataModel.AnnouncementType,
            Title = announcementDataModel.Title,
            PublishStartDate = announcementDataModel.PublishStartDate,
            PublishEndDate = announcementDataModel.PublishEndDate,
            Content = announcementDataModel.Content,
            DisplayState = announcementDataModel.DisplayState,
            IsTop = announcementDataModel.IsTop,
            Boost = announcementDataModel.Boost,
            PublishStatus = announcementDataModel.PublishStatus,
        };
        return resultDto;
    }

    /// <summary>
    /// 新增公告
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns></returns>
    public async Task<bool> InsertAsync(AnnouncementInsertParameterDto parameter)
    {
        var dataModel = new Announcement
        {
            AnnouncementType = parameter.AnnouncementType,
            Title = parameter.Title,
            PublishStartDate = parameter.PublishStartDate,
            PublishEndDate = parameter.PublishEndDate,
            PublishStatus = parameter.PublishStatus,
            Content = parameter.Content,
            DisplayState = parameter.DisplayState,
            IsTop = parameter.IsTop,
            Boost = parameter.Boost,
            CreateTime = DateTime.Now,
            UpdateTime = DateTime.Now
        };
        return await announcementRepository.InsertAsync(dataModel);
    }

    /// <summary>
    /// 更新公告
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns></returns>
    public async Task<bool> UpdateAsync(AnnouncementUpdateParameterDto parameter)
    {
        var announcement = await announcementRepository.GetAsync(parameter.Id);
        if (announcement is null)
        {
            return false;
        }
        
        announcement.AnnouncementType = parameter.AnnouncementType;
        announcement.Title = parameter.Title;
        announcement.PublishStartDate = parameter.PublishStartDate;
        announcement.PublishEndDate = parameter.PublishEndDate;
        announcement.PublishStatus = parameter.PublishStatus;
        announcement.Content = parameter.Content;
        announcement.DisplayState = parameter.DisplayState;
        announcement.IsTop = parameter.IsTop;
        announcement.Boost = parameter.Boost;
        announcement.UpdateTime = DateTime.Now;

        return await announcementRepository.UpdateAsync(announcement);
    }
}