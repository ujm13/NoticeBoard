using System.ComponentModel;

namespace NoticeBoard.Common.Enums;

public enum AnnouncementType
{
    [Description("技術通告")]
    Technology,
    
    [Description("客服通告")]
    Customer ,
    
    [Description("起保通告")]
    Insurance
    
    
}