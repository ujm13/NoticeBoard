using System.ComponentModel;

namespace NoticeBoard.Common.Extensions;

public static class EnumExtensions
{
    /// <summary>
    /// 取得 Enum 的 Description
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string GetDescription(this Enum value)
    {
        var type = value.GetType();
        var name = Enum.GetName(type, value);
        if (name == null)
        {
            return string.Empty;
        }

        var field = type.GetField(name);
        if (field == null)
        {
            return string.Empty;
        }

        var attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
        return attr?.Description ?? string.Empty;
    }
}