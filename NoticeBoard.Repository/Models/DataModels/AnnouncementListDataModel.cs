﻿using NoticeBoard.Common.Enums;

namespace NoticeBoard.Repository.Models.DataModels;

public class AnnouncementListDataModel
{
    /// <summary>
    /// Id
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
    /// 發佈日期
    /// </summary>
    public DateTime PublishDate { get; set; }
    
    /// <summary>
    /// 發佈狀態
    /// </summary>
    public PublishStatus PublishStatus { get; set; }
}