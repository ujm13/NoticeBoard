using System.ComponentModel;

namespace NoticeBoard.Common.Enums;

public enum PublishStatus
{
    [Description("已發佈")]
    Published,
    
    [Description("未發佈")]
    Draft
}