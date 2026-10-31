# Consolidated · Masoneilan 中文销售联系站

面向中国客户的 ASP.NET Core 10 销售联系网站，集中展示贝克休斯旗下 Consolidated 与 Masoneilan 阀门品牌的联系入口。

## 联系人

- 黄海宏
- 电话：18001547123
- 邮箱：king.huang@bakerhughes.com

## 网站内容

- 中文响应式单页，适配桌面、平板和手机。
- Consolidated 安全泄压阀和 Masoneilan 控制阀及仪表品牌介绍。
- 一键拨打电话、发送邮件和复制联系方式。
- 中文标题、描述、Canonical、Open Graph、Twitter Card 和结构化数据。
- `robots.txt`、`sitemap.xml` 和 `/health`。
- 自定义 404 页面、安全响应头、键盘焦点和减少动态效果支持。

## 本地运行

项目已包含本地 .NET 10 SDK，可直接执行：

```powershell
.\work\dotnet\dotnet.exe run --project .\src\ConsolidatedMasoneilanContact
```

如果系统已经安装 .NET 10 SDK：

```powershell
dotnet run --project .\src\ConsolidatedMasoneilanContact
```

浏览器打开终端显示的本地地址。当前默认开发地址为 `http://localhost:5067`。

## 测试

```powershell
.\work\dotnet\dotnet.exe test .\tests\ConsolidatedMasoneilanContact.Tests
```

测试覆盖中文联系人信息、SEO 元数据、结构化数据、站点地图、robots、健康检查、安全头、404 页面、静态资源和复制交互所需资源。

## 联系方式维护

联系人、电话、邮箱和页面文案统一维护在：

`src/ConsolidatedMasoneilanContact/Models/SiteContentCatalog.cs`

测试会验证核心联系方式，修改后可运行测试确认没有遗漏。

## 图片来源

阀门场景图片取自 Baker Hughes 阀门官方网站的公开 Consolidated 与 Masoneilan 品牌页面素材：

- https://valves.bakerhughes.com/

正式上线前，请由品牌或法务负责人确认这些素材的持续使用授权。

## 上线

公网网站需要域名和服务器。完整步骤见 [DEPLOYMENT.md](DEPLOYMENT.md)。
