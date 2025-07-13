namespace HotUpdateX.PluginContracts;

/// <summary>
/// 插件元数据（Plugin metadata info）
/// </summary>
public class PluginInfo
{
    /// <summary>
    /// 插件唯一ID / Unique plugin ID
    /// </summary>
    public string Id { get; set; } = string.Empty;
    /// <summary>
    /// 插件名称 / Plugin name
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// 插件作者 / Plugin author
    /// </summary>
    public string Author { get; set; } = string.Empty;
    /// <summary>
    /// 插件描述 / Plugin description
    /// </summary>
    public string Description { get; set; } = string.Empty;
    /// <summary>
    /// 插件版本 / Plugin version
    /// </summary>
    public string Version { get; set; } = string.Empty;
    /// <summary>
    /// 插件类型（如 source/config/other）/ Plugin type (e.g., source/config/other)
    /// </summary>
    public string? Type { get; set; }
    /// <summary>
    /// 插件官网 / Plugin website
    /// </summary>
    public string? Website { get; set; }
    /// <summary>
    /// 支持的功能列表 / Supported features
    /// </summary>
    public string[]? Features { get; set; }
    /// <summary>
    /// 插件最后更新时间（ISO8601）/ Last update time (ISO8601)
    /// </summary>
    public string? UpdateTime { get; set; }
} 