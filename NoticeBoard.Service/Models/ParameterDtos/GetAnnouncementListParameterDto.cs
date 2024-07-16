﻿namespace NoticeBoard.Service.Models.ParameterDtos;

public class GetAnnouncementListParameterDto
{
    /// <summary>
    /// 起始時間
    /// </summary>
    public DateTime? StartDate { get; set; }
    
    /// <summary>
    /// 結束時間
    /// </summary>
    public DateTime? EndDate { get; set; }
    
    /// <summary>
    /// 標題
    /// </summary>
    public string? Title { get; set; }
}