namespace HotUpdateX.PluginContracts;

public class ConfigSchemaItem
{
    /// <summary>
    /// 配置项唯一 key / Unique key for the config item
    /// </summary>
    public string Key { get; set; } = string.Empty;
    /// <summary>
    /// UI 显示名 / UI display name
    /// </summary>
    public string Label { get; set; } = string.Empty;
    /// <summary>
    /// 类型（string/int/bool/enum等）/ Type (string/int/bool/enum, etc.)
    /// </summary>
    public string Type { get; set; } = "string";
    /// <summary>
    /// 描述 / Description
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// 默认值 / Default value
    /// </summary>
    public string? DefaultValue { get; set; }
    /// <summary>
    /// 枚举可选值 / Enum selectable values
    /// </summary>
    public IEnumerable<string>? EnumValues { get; set; }
    /// <summary>
    /// 是否必填 / Is required
    /// </summary>
    public bool Required { get; set; } = false;
    /// <summary>
    /// 分组名 / Group name
    /// </summary>
    public string? Group { get; set; }
    /// <summary>
    /// 排序权重 / Order
    /// </summary>
    public int Order { get; set; } = 0;
    /// <summary>
    /// 是否为高级项 / Is advanced
    /// </summary>
    public bool Advanced { get; set; } = false;
} 