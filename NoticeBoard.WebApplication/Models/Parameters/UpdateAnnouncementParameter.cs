using NoticeBoard.Common.Enums;

namespace NoticeBoard.WebApplication.Models.Parameters;

public class UpdateAnnouncementParameter
{
    /// <summary>
    /// 公告編號
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// 公告類型
    /// </summary>
    public AnnouncementType AnnouncementType { get; set; }
    
    /// <summary>
    /// 標題
    /// </summary>
    public string Title { get; set; }
    
    /// <summary>
    /// 上架時間
    /// </summary>
    public DateTime PublishStartDate { get; set; }

    /// <summary>
    /// 上架結束時間
    /// </summary>
    public DateTime PublishEndDate { get; set; }
    
    /// <summary>
    /// 發布狀態
    /// </summary>
    public PublishStatus PublishStatus { get; set; }
    
    /// <summary>
    /// 內容
    /// </summary>
    public string Content { get; set; }
    
    /// <summary>
    /// 顯示狀態
    /// </summary>
    public DisplayState DisplayState { get; set; }

    /// <summary>
    /// 是否置頂
    /// </summary>
    public bool IsTop { get; set; }

    /// <summary>
    /// 權重
    /// </summary>
    public int Boost { get; set; }
}