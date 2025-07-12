namespace HotUpdateX.PluginContracts;

public class SoftwareInfo
{
    /// <summary>
    /// 软件名称 / Software name
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// 源名称（如 GitHub、Gitee）/ Source name (e.g., GitHub, Gitee)
    /// </summary>
    public string SourceName { get; set; } = string.Empty;
    /// <summary>
    /// 仓库地址或唯一标识 / Repo address or unique identifier
    /// </summary>
    public string RepoAddress { get; set; } = string.Empty;
    /// <summary>
    /// 版本号正则表达式 / Version regex
    /// </summary>
    public string VersionRegex { get; set; } = string.Empty;
    /// <summary>
    /// 更新地址正则表达式 / Update URL regex
    /// </summary>
    public string UpdateUrlRegex { get; set; } = string.Empty;
    /// <summary>
    /// 软件图标地址 / Icon URL
    /// </summary>
    public string? IconUrl { get; set; }
    /// <summary>
    /// 当前版本 / Current version
    /// </summary>
    public string? CurrentVersion { get; set; }
    /// <summary>
    /// 最新版本 / Latest version
    /// </summary>
    public string? LatestVersion { get; set; }
    /// <summary>
    /// 下载地址 / Download URL
    /// </summary>
    public string? DownloadUrl { get; set; }
    /// <summary>
    /// 作者 / Author
    /// </summary>
    public string? Author { get; set; }
    /// <summary>
    /// 描述 / Description
    /// </summary>
    public string? Description { get; set; }
} 