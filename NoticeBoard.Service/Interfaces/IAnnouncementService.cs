using NoticeBoard.Repository.Entities;
using NoticeBoard.Service.Models.ParameterDtos;
using NoticeBoard.Service.Models.ResultDtos;

namespace NoticeBoard.Service.Interfaces;

public interface IAnnouncementService
{
    /// <summary>
    /// 取得公告列表
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns></returns>
    Task<IEnumerable<AnnouncementListResultDto>> GetListAsync(GetAnnouncementListParameterDto parameter);

    /// <summary>
    /// 取得公告明細
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<AnnouncementResultDto?> GetAsync(int id);


    /// <summary>
    /// 新增公告
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns></returns>
    Task<bool> InsertAsync(AnnouncementInsertParameterDto parameter);

    /// <summary>
    /// 更新公告
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns></returns>
    Task<bool> UpdateAsync(AnnouncementUpdateParameterDto parameter);
}