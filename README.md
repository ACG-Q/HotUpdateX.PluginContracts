# HotUpdateX.PluginContracts

本包为 HotUpdateX 主程序与插件之间的契约数据结构，推荐插件开发者和主程序都引用本包，进行 JSON 序列化/反序列化。

## 约定数据结构

- PluginInfo：插件元数据（支持 Type、Website、Features、UpdateTime 等）
- SoftwareInfo：软件信息（支持 IconUrl、CurrentVersion、LatestVersion、DownloadUrl、Author、Description 等）
- ConfigSchemaItem：插件配置项描述（支持 Required、Group、Order、Advanced 等）

---

## 字段详细说明

### PluginInfo
| 字段名         | 类型         | 说明（中/英）                                                                 | 示例值                  |
|----------------|--------------|-------------------------------------------------------------------------------|-------------------------|
| Id             | string       | 插件唯一ID（如 github、gitee）/ Unique plugin ID (e.g., github, gitee)        | "github"               |
| Name           | string       | 插件名称 / Plugin name                                                        | "GitHub 源"           |
| Author         | string       | 插件作者 / Plugin author                                                      | "acg-q"               |
| Description    | string       | 插件描述 / Plugin description                                                 | "支持 GitHub 软件源"   |
| Version        | string       | 插件版本 / Plugin version                                                     | "1.0.0"               |
| Type           | string?      | 插件类型（如 source/config/other）/ Plugin type (e.g., source/config/other)   | "source"              |
| Website        | string?      | 插件官网 / Plugin website                                                     | "https://example.com"  |
| Features       | string[]?    | 支持的功能列表 / Supported features                                           | ["check-update"]       |
| UpdateTime     | string?      | 插件最后更新时间（ISO8601）/ Last update time (ISO8601)                      | "2024-05-01T12:00:00Z" |

### SoftwareInfo
| 字段名         | 类型         | 说明（中/英）                                                                 | 示例值                  |
|----------------|--------------|-------------------------------------------------------------------------------|-------------------------|
| Name           | string       | 软件名称 / Software name                                                      | "Notepad++"            |
| SourceName     | string       | 源名称（如 GitHub、Gitee）/ Source name (e.g., GitHub, Gitee)                 | "GitHub"               |
| RepoAddress    | string       | 仓库地址或唯一标识 / Repo address or unique identifier                        | "acg-q/HotUpdateX"     |
| VersionRegex   | string       | 版本号正则表达式 / Version regex                                              | "v?(\\d+\\.\\d+\\.\\d+)" |
| UpdateUrlRegex | string       | 更新地址正则表达式 / Update URL regex                                         | "/releases"            |
| IconUrl        | string?      | 软件图标地址 / Icon URL                                                       | "https://.../icon.png" |
| CurrentVersion | string?      | 当前版本 / Current version                                                    | "1.0.0"                |
| LatestVersion  | string?      | 最新版本 / Latest version                                                     | "1.2.0"                |
| DownloadUrl    | string?      | 下载地址 / Download URL                                                       | "https://.../dl.zip"   |
| Author         | string?      | 作者 / Author                                                                 | "acg-q"                |
| Description    | string?      | 描述 / Description                                                            | "文本编辑器"           |

### ConfigSchemaItem
| 字段名      | 类型              | 说明（中/英）                                                        | 示例值           |
|-------------|-------------------|-----------------------------------------------------------------------|------------------|
| Key         | string            | 配置项唯一 key / Unique key for the config item                       | "apiToken"      |
| Label       | string            | UI 显示名 / UI display name                                           | "API 密钥"      |
| Type        | string            | 类型（string/int/bool/enum等）/ Type (string/int/bool/enum, etc.)     | "string"        |
| Description | string?           | 描述 / Description                                                    | "用于认证"      |
| DefaultValue| string?           | 默认值 / Default value                                                | "mock-token"    |
| EnumValues  | IEnumerable<string>? | 枚举可选值 / Enum selectable values                                 | ["A", "B"]     |
| Required    | bool              | 是否必填 / Is required                                                | true             |
| Group       | string?           | 分组名 / Group name                                                   | "高级"          |
| Order       | int               | 排序权重 / Order                                                      | 0                |
| Advanced    | bool              | 是否为高级项 / Is advanced                                            | false            |

---

## 推荐插件实现方式

```csharp
using HotUpdateX.PluginContracts;
using System.Text.Json;

public class PluginEntry
{
    public string GetPluginInfo()
    {
        var info = new PluginInfo
        {
            Id = "template",
            Name = "模板源",
            Author = "xxx",
            Description = "描述",
            Version = "1.0.0",
            Type = "source",
            Website = "https://example.com",
            Features = new[] { "check-update", "download" },
            UpdateTime = DateTime.UtcNow.ToString("o")
        };
        return JsonSerializer.Serialize(info);
    }
    // 其它方法同理
}
```

## 主程序用法

```csharp
using HotUpdateX.PluginContracts;
using System.Text.Json;

// 反射调用后
var json = getInfo.Invoke(instance, null) as string;
var info = JsonSerializer.Deserialize<PluginInfo>(json);
```

## JSON 格式示例

```json
{
  "id": "template",
  "name": "模板源",
  "author": "xxx",
  "description": "描述",
  "version": "1.0.0",
  "type": "source",
  "website": "https://example.com",
  "features": ["check-update", "download"],
  "updateTime": "2024-05-01T12:00:00Z"
}
``` 