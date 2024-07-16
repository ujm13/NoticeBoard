using NoticeBoard.Repository.Entities;
using NoticeBoard.Repository.Models.DataModels;
using NoticeBoard.Repository.Models.ParameterModels;

namespace NoticeBoard.Repository.Interfaces;

public interface IAnnouncementRepository
{
    /// <summary>
    /// 取得公告列表
    /// </summary>
    /// <param name="parameterModel"></param>
    /// <returns></returns>
    Task<IEnumerable<AnnouncementListDataModel>> GetListAsync(GetAnnouncementListParameterModel parameterModel);

    /// <summary>
    /// 取得公告明細
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<AnnouncementDataModel?> GetDetailAsync(int id);
    
    /// <summary>
    /// 取得公告
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Announcement?> GetAsync(int id);

    /// <summary>
    /// 新增公告
    /// </summary>
    /// <param name="announcement"></param>
    /// <returns></returns>
    Task<bool> InsertAsync(Announcement announcement);

    /// <summary>
    /// 更新公告
    /// </summary>
    /// <param name="announcement"></param>
    /// <returns></returns>
    Task<bool> UpdateAsync(Announcement announcement);
}