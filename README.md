# HotUpdateX.PluginContracts 契约说明

本包定义 HotUpdateX 主程序与插件之间的标准数据结构和方法协议，确保插件生态的可扩展性和一致性。

---

## 1. 插件信息格式（PluginInfo）

| 字段名      | 类型     | 说明（中/英）                                      | 示例值                  |
|-------------|----------|---------------------------------------------------|-------------------------|
| Id          | string   | 插件唯一ID / Unique plugin ID                     | "github"               |
| Name        | string   | 插件名称 / Plugin name                            | "GitHub 源"           |
| Author      | string   | 插件作者 / Plugin author                          | "acg-q"               |
| Description | string   | 插件描述 / Plugin description                     | "支持 GitHub 软件源"   |
| Version     | string   | 插件版本 / Plugin version                         | "1.0.0"               |
| Type        | string?  | 插件类型（如 source/config/other）/ Plugin type   | "source"              |
| Website     | string?  | 插件官网 / Plugin website                         | "https://example.com"  |
| Features    | string[]?| 支持的功能列表 / Supported features               | ["check-update"]       |
| UpdateTime  | string?  | 插件最后更新时间（ISO8601）/ Last update time    | "2024-05-01T12:00:00Z" |

---

## 2. 契约方法统一参数协议

### 2.1 Info()
- **用途**：获取插件元数据。
- **输入**：无
- **输出**：PluginInfo 的 JSON 字符串
- **输出示例**：
```json
{
  "Id": "github",
  "Name": "GitHub 源",
  "Author": "acg-q",
  "Description": "支持 GitHub 软件源",
  "Version": "1.0.0",
  "Type": "source",
  "Website": "https://example.com",
  "Features": ["check-update"],
  "UpdateTime": "2024-05-01T12:00:00Z"
}
```

### 2.2 ConfigSchema()
- **用途**：获取插件支持的配置项 schema。
- **输入**：无
- **输出**：配置项 schema 的 JSON 字符串（List<ConfigSchemaItem>）
- **输出示例**：
```json
[
  {
    "Key": "token",
    "Label": "GitHub Token",
    "Type": "string",
    "Description": "用于访问私有仓库的 GitHub Token",
    "DefaultValue": "",
    "Required": false
  }
]
```

### 2.3 Config(string json)
- **用途**：应用插件配置。
- **输入**：JSON 字符串，内容为 key-value 配置项
- **输入示例**：
```json
{
  "token": "ghp_xxx"
}
```
- **输出**：无

### 2.4 CheckUpdate()
- **用途**：检查插件自身是否有新版本。
- **输入**：无
- **输出**：{ "hasUpdate": bool } 的 JSON 字符串
- **输出示例**：
```json
{ "hasUpdate": false }
```

### 2.5 Update()
- **用途**：升级插件自身。
- **输入**：无
- **输出**：{ "success": bool } 的 JSON 字符串
- **输出示例**：
```json
{ "success": false }
```

### 2.6 Match(string input)
- **用途**：来源识别与配置生成。主程序遍历所有插件，找到能解析该来源的插件，并自动生成软件配置。
- **输入**：用户输入的来源URL、repo、ID等（主程序无需加工，直接传递）
- **输入示例**：
```json
"https://github.com/acg-q/HotUpdateX"
```
- **输出**：如果匹配本插件，返回标准 SoftwareInfo JSON，否则返回 null/空字符串。
- **输出示例**：
```json
{
  "Name": "HotUpdateX",
  "SourceId": "github",
  "VersionRegex": "v?(\\d+\\.\\d+\\.\\d+)",
  "IconUrl": "https://github.com/acg-q.png",
  "LatestVersion": "1.2.0",
  "Author": "acg-q",
  "Description": "HotUpdateX 主程序"
}
```

### 2.7 Search(string keyword)
- **用途**：关键字搜索。主程序在“添加软件”或“搜索软件”时聚合所有插件的搜索结果。
- **输入**：用户输入的部分字符串或关键字
- **输入示例**：
```json
"telegram"
```
- **输出**：SoftwareInfo JSON数组，可为空。
- **输出示例**：
```json
[
  {
    "Name": "Telegram Desktop",
    "SourceId": "web",
    "VersionRegex": "",
    "IconUrl": "https://desktop.telegram.org/img/telegram-logo.png",
    "LatestVersion": "5.0.1",
    "Author": "Telegram",
    "Description": "Telegram 官方桌面版"
  }
]
```

### 2.8 LatestAssets(SoftwareInfo info)
- **用途**：根据 SoftwareInfo 获取当前软件的最新版本及所有可用下载连接（如多平台、多格式）。
- **输入**：SoftwareInfo JSON
- **输入示例**：
```json
{
  "Name": "Telegram Desktop",
  "SourceId": "web",
  "VersionRegex": "",
  "IconUrl": "https://desktop.telegram.org/img/telegram-logo.png",
  "LatestVersion": "5.0.1",
  "Author": "Telegram",
  "Description": "Telegram 官方桌面版"
}
```
- **输出**：包含版本号和下载项（名称+URL）的 JSON 对象或数组。
- **输出示例**：
```json
{
  "Version": "5.0.1",
  "Assets": [
    { "Name": "Windows x64 安装包", "Url": "https://updates.tdesktop.com/tsetup/tsetup.5.0.1.exe" },
    { "Name": "macOS DMG", "Url": "https://updates.tdesktop.com/tsetup/tsetup.5.0.1.dmg" },
    { "Name": "Linux tar.xz", "Url": "https://updates.tdesktop.com/tsetup/tsetup.5.0.1.tar.xz" }
  ]
}
```

--- 