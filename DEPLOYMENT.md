# 上线与搜索收录指南

## 当前状态

网站已经可以构建、运行和发布，但尚未部署到公网。没有公网域名时，客户无法通过搜索引擎找到此网站，百度、必应和 Google 也无法完成正式收录。

## 1. 准备域名和主机

建议准备：

- 一个简短、易记的独立域名。
- 支持 .NET 10 的 Windows IIS 主机，或 Linux 主机。
- 有效的 HTTPS 证书。
- 若服务器位于中国大陆，先确认域名备案和 ICP 要求。

## 2. 发布应用

在项目根目录运行：

```powershell
.\work\dotnet\dotnet.exe publish .\src\ConsolidatedMasoneilanContact --configuration Release --output .\work\publish
```

发布结果不包含数据库、密钥或第三方跟踪脚本。

## 3. Windows IIS

1. 安装 .NET 10 ASP.NET Core Hosting Bundle。
2. 在 IIS 中创建站点，并将站点物理路径指向 `work\publish` 中的发布结果。
3. 绑定域名和 HTTPS 证书。
4. 确认应用池使用“无托管代码”。
5. 将网站根地址强制跳转至 HTTPS。

## 4. Linux 反向代理

项目采用标准 Kestrel + 反向代理模式：

1. 将发布目录上传到服务器。
2. 使用 `systemd` 运行 `dotnet ConsolidatedMasoneilanContact.dll`。
3. 用 Nginx 或同类反向代理提供 HTTPS。
4. 将代理的 `X-Forwarded-Proto` 和 `X-Forwarded-For` 头传给应用。
5. 如果反向代理不与应用运行在同一台受信任主机上，需要在 `Program.cs` 的 `ForwardedHeadersOptions` 中配置明确的受信任代理；只信任实际代理地址，不要无条件信任公网请求头。

## 5. 域名与 DNS

配置：

- 根域名或 `www` 的 A/AAAA/CNAME 记录。
- `http://` 到 `https://` 的 301 跳转。
- 只保留一个公开 Canonical 域名。

网站会依据实际请求域名自动生成 Canonical、`robots.txt` 中的站点地图地址和 `sitemap.xml` 中的页面地址。

## 6. 提交搜索引擎

域名和 HTTPS 生效后，分别注册并验证：

- 百度搜索资源平台
- Bing Webmaster Tools
- Google Search Console

提交以下地址：

- `https://你的域名/`
- `https://你的域名/sitemap.xml`

搜索排名不作保证。收录前需要保证：

- 域名能被公网访问。
- `robots.txt` 没有阻止抓取。
- 网站证书有效。
- Google Search Console、Bing 或百度完成站点所有权验证。
- 网站持续在线并提供与搜索意图一致的联系人和产品信息。

## 7. 上线验收

依次检查：

```text
https://你的域名/
https://你的域名/robots.txt
https://你的域名/sitemap.xml
https://你的域名/health
```

手机和电脑上分别确认：

- 黄海宏、电话和邮箱显示正确。
- “拨打电话”打开手机拨号界面。
- “发送邮件”打开默认邮件应用。
- 复制电话号码和邮箱地址可用。
- 浏览器地址栏显示 HTTPS。
