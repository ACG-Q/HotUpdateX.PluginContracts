namespace HotUpdateX.PluginContracts;

/// <summary>
/// 软件信息（Software info for software item）
/// </summary>
public class SoftwareInfo
{
    /// <summary>
    /// 软件名称 / Software name
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// 源插件ID（如 github、web、store 等）/ Source plugin ID (e.g., github, web, store)
    /// </summary>
    public string SourceId { get; set; } = string.Empty;
    /// <summary>
    /// 软件图标地址 / Icon URL
    /// </summary>
    public string? IconUrl { get; set; }
    /// <summary>
    /// 作者 / Author
    /// </summary>
    public string? Author { get; set; }
    /// <summary>
    /// 其它扩展字段（如版本、描述、正则等，插件可自由扩展）/ Extra fields (e.g., version, description, regex, etc., plugin-defined)
    /// </summary>
    public Dictionary<string, object>? Extra { get; set; }
} 