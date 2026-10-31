# Consolidated and Masoneilan Chinese Contact Site Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Build a Chinese ASP.NET Core 10 sales contact website for Consolidated and Masoneilan that makes 黄海宏 immediately reachable and exposes complete search-engine metadata.

**Architecture:** A static-content Razor Pages application with no database. Strongly typed site content feeds a server-rendered Chinese page, SEO partials, `robots.txt`, `sitemap.xml`, and a health endpoint. A custom industrial visual system informed by the public Baker Hughes Valves website and one locally hosted brand scene provide the presentation.

**Tech Stack:** .NET 10, ASP.NET Core Razor Pages, xUnit, `Microsoft.AspNetCore.Mvc.Testing`, vanilla CSS/JavaScript, generated WebP hero image.

**Spec:** `docs/superpowers/specs/2026-10-31-consolidated-masoneilan-contact-design.md`

## Global Constraints

- The customer-facing site is entirely in Simplified Chinese.
- 黄海宏's phone number is exactly `18001547123`; its call URI is `tel:+8618001547123`.
- 黄海宏's email address is exactly `king.huang@bakerhughes.com`.
- Do not invent a job title, office, business hours, response time, inventory, certification, or regional coverage.
- Consolidated is described only as safety relief valve products; Masoneilan only as control valve and instrumentation products.
- The canonical route is `/`.
- Use ASP.NET Core 10, `WebApplicationBuilder`, and `WebApplication`.
- No database, authentication, contact form, analytics, chat, or third-party tracking.
- Primary colors are navy `#071D2B`, ink `#102733`, teal `#02BC94`, deep teal `#018374`, white `#FFFFFF`, cool white `#F5F7F6`, muted ink `#58707C`, and border `#D9E1E3`.
- Search wording must cover Chinese customer intent for 康索尼德、梅索尼兰、销售联系方式、安全阀、控制阀、黄海宏.
- Public indexing and ranking are not guaranteed until a domain and hosting are supplied.

---

### Task 1: Capture the Accepted Visual Reference

**Files:**
- Create: `work/design/reference-valves-home.png`
- Create: `work/design/reference-styles.json`
- Create: `work/design/reference-media.json`
- Read: `C:/Users/tyhua/.codex/skills/imagegen/SKILL.md`
- Read: `C:/Users/tyhua/.codex/plugins/cache/openai-api-curated/build-web-apps/0722921d/skills/frontend-app-builder/references/imagegen-website-concepts.md`

**Interfaces:**
- Consumes: visual direction and exact Chinese copy from the spec.
- Produces: captured reference evidence and the accepted Baker Hughes-inspired visual system used for implementation comparison.

**Reference direction:**

```text
Create a polished Chinese industrial valve sales contact page by combining the confirmed editorial structure with the Baker Hughes Valves visual language.
Brands: Consolidated and Masoneilan, brands of Baker Hughes.
Audience: Chinese procurement teams, process engineers, maintenance teams, and EPC project teams.
Style: clean white navigation, deep navy #071D2B, vivid teal #02BC94 and deep teal #018374,
large Chinese display headline, clean Chinese sans-serif body, thin technical rules,
open bands, one strong valve manufacturing photograph, no generic card grid, no glow, no decorative pills.
Hero headline: 可靠阀门方案，从一次直接沟通开始
Supporting copy: 面向中国客户，提供 Consolidated 安全泄压阀与 Masoneilan 控制阀及仪表产品咨询。
Primary action: 联系销售
Navigation: 产品品牌, 联系方式
The first viewport must include a restrained header, hero copy on a deep photographic valve scene, and a clear
contact action. Include the beginning of the brand section below the fold. Keep interface text code-native.
Do not invent logos, statistics, offices, certifications, or claims.
```

- [ ] **Step 1: Capture the official reference**

Open `https://valves.bakerhughes.com/` with Playwright, capture the first viewport to `work/design/reference-valves-home.png`, and record computed styles and public image URLs in the JSON evidence files.

- [ ] **Step 2: Extract the visual system**

Record the white header, teal accents, font family/scale, dark hero treatment, image URLs, and open band rhythm in `docs/superpowers/plans/2026-10-31-design-system.md`.

- [ ] **Step 3: Select the hero asset**

Use one of the public Baker Hughes Valves Consolidated or Masoneilan banner assets as the locally hosted hero image. Preserve the photography without adding an unapproved flat color wash; use a directional gradient only if it is required for text contrast.

- [ ] **Step 4: Record implementation evidence**

If image inspection is unavailable in the model runtime, retain the captured screenshot and DOM evidence and use browser screenshot dimensions plus computed styles as the comparison source. Record this limitation in the fidelity ledger.

- [ ] **Step 5: Record the design system**

Write the final token values, font scale, spacing, container widths, imagery treatment, button geometry, and responsive rules into `docs/superpowers/plans/2026-10-31-design-system.md`.

- [ ] **Step 6: Commit the accepted references**

```powershell
git add work/design/reference-valves-home.png work/design/reference-styles.json work/design/reference-media.json docs/superpowers/plans/2026-10-31-design-system.md
git commit -m "design: add accepted contact site concept"
```

### Task 2: Bootstrap the ASP.NET Core Solution and Failing Integration Tests

**Files:**
- Create: `ConsolidatedMasoneilanContact.sln`
- Create: `src/ConsolidatedMasoneilanContact/ConsolidatedMasoneilanContact.csproj`
- Create: `tests/ConsolidatedMasoneilanContact.Tests/ConsolidatedMasoneilanContact.Tests.csproj`
- Create: `tests/ConsolidatedMasoneilanContact.Tests/PublicSiteTests.cs`
- Create: `Directory.Build.props`
- Create: `.gitignore`
- Create: `work/install-dotnet.ps1`

**Interfaces:**
- Consumes: the installed local .NET 10 SDK under `work/dotnet`.
- Produces: a solution whose test project locates the app entry point and asserts the first Chinese route contract.

**Project settings:**

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">
  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>
</Project>
```

**Initial failing test:**

```csharp
public sealed class PublicSiteTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    [Fact]
    public async Task Chinese_home_page_exposes_primary_contact()
    {
        var client = factory.CreateClient();
        var response = await client.GetAsync("/");
        var html = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("黄海宏", html);
        Assert.Contains("18001547123", html);
        Assert.Contains("king.huang@bakerhughes.com", html);
    }
}
```

- [ ] **Step 1: Install a project-local .NET 10 SDK**

Download the official `dotnet-install.ps1` script into `work/`, install channel `10.0` to `work/dotnet`, and use `work/dotnet/dotnet.exe` for all later commands.

- [ ] **Step 2: Create the solution and minimal host**

Run the equivalent of `dotnet new sln`, `dotnet new webapp`, and `dotnet new xunit`, add the project references, and expose `public partial class Program;` so the web host can be tested.

- [ ] **Step 3: Add the failing route test**

Paste the test above and add package references `Microsoft.NET.Test.Sdk`, `xunit`, `xunit.runner.visualstudio`, and `Microsoft.AspNetCore.Mvc.Testing` version `10.*`.

- [ ] **Step 4: Run the focused test to verify failure**

```powershell
work/dotnet/dotnet.exe test tests/ConsolidatedMasoneilanContact.Tests --filter Chinese_home_page_exposes_primary_contact
```

Expected: FAIL because the generated template does not contain the requested contact information.

- [ ] **Step 5: Commit the test harness and failing test**

```powershell
git add Directory.Build.props ConsolidatedMasoneilanContact.sln src tests work/install-dotnet.ps1 .gitignore
git commit -m "test: bootstrap contact site integration tests"
```

### Task 3: Implement Typed Content and the Chinese Razor Page

**Files:**
- Create: `src/ConsolidatedMasoneilanContact/Models/SalesContact.cs`
- Create: `src/ConsolidatedMasoneilanContact/Models/SiteContent.cs`
- Create: `src/ConsolidatedMasoneilanContact/Pages/Index.cshtml.cs`
- Modify: `src/ConsolidatedMasoneilanContact/Pages/Index.cshtml`
- Modify: `src/ConsolidatedMasoneilanContact/Pages/Shared/_Layout.cshtml`
- Create: `src/ConsolidatedMasoneilanContact/Pages/Shared/_BrandSection.cshtml`
- Create: `src/ConsolidatedMasoneilanContact/Pages/Shared/_ContactSection.cshtml`
- Test: `tests/ConsolidatedMasoneilanContact.Tests/PublicSiteTests.cs`

**Interfaces:**

```csharp
public sealed record SalesContact(
    string Name,
    string DisplayPhone,
    string PhoneUri,
    string Email);

public sealed record BrandProfile(
    string Name,
    string ChineseName,
    string Description);

public sealed record SiteContent(
    string Title,
    string Description,
    string HeroHeading,
    string HeroSummary,
    IReadOnlyList<BrandProfile> Brands,
    SalesContact Contact);

public static class SiteContentCatalog
{
    public static SiteContent Chinese { get; }
}
```

**Exact content:**

```csharp
Title = "康索尼德与梅索尼兰销售联系方式 | 黄海宏 | Baker Hughes";
Description = "查找康索尼德（Consolidated）安全泄压阀与梅索尼兰（Masoneilan）控制阀销售联系方式。联系人黄海宏，电话 18001547123，邮箱 king.huang@bakerhughes.com。";
HeroHeading = "可靠阀门方案，从一次直接沟通开始";
HeroSummary = "面向中国客户，提供 Consolidated 安全泄压阀与 Masoneilan 控制阀及仪表产品咨询。";
```

- [ ] **Step 1: Add failing content assertions**

Extend the integration test to assert the H1, title, description, both brand names, the `tel:` URI, and the `mailto:` URI.

- [ ] **Step 2: Run the tests to verify failure**

```powershell
work/dotnet/dotnet.exe test tests/ConsolidatedMasoneilanContact.Tests --filter Chinese_home_page_exposes_primary_contact
```

Expected: FAIL on the missing H1 or metadata.

- [ ] **Step 3: Implement the records and content catalog**

Create the three records and `SiteContentCatalog.Chinese` exactly as declared above. Leave no contact facts duplicated in Razor markup.

- [ ] **Step 4: Build the semantic page**

Create one H1, a brand section with one `<article>` per brand, and a contact section with:

```html
<a class="contact-action contact-action--primary" href="@Model.Content.Contact.PhoneUri">
  <span>拨打电话</span>
</a>
<a class="contact-action" href="mailto:@Model.Content.Contact.Email">
  <span>发送邮件</span>
</a>
```

Use `<main>`, `<nav aria-label="主要导航">`, `<section aria-labelledby>`, and `<footer>`. Do not invent claims.

- [ ] **Step 5: Run the focused tests to verify they pass**

```powershell
work/dotnet/dotnet.exe test tests/ConsolidatedMasoneilanContact.Tests --filter Chinese_home_page_exposes_primary_contact
```

Expected: PASS.

- [ ] **Step 6: Commit the content and page**

```powershell
git add src tests
git commit -m "feat: add Chinese sales contact page"
```

### Task 4: Add SEO, Sitemap, Robots, Security Headers, and Branded 404

**Files:**
- Create: `src/ConsolidatedMasoneilanContact/Infrastructure/SiteUrlBuilder.cs`
- Create: `src/ConsolidatedMasoneilanContact/Infrastructure/SiteEndpoints.cs`
- Create: `src/ConsolidatedMasoneilanContact/Pages/Error.cshtml`
- Create: `src/ConsolidatedMasoneilanContact/Pages/Error.cshtml.cs`
- Create: `src/ConsolidatedMasoneilanContact/Pages/Shared/_SeoMeta.cshtml`
- Modify: `src/ConsolidatedMasoneilanContact/Pages/Shared/_Layout.cshtml`
- Modify: `src/ConsolidatedMasoneilanContact/Program.cs`
- Test: `tests/ConsolidatedMasoneilanContact.Tests/SeoAndOperationalTests.cs`

**Interfaces:**

```csharp
public static string Absolute(HttpRequest request, string path);
public static IEndpointRouteBuilder MapSiteOperations(this IEndpointRouteBuilder endpoints);
```

**Required tests:**

```csharp
[Theory]
[InlineData("/robots.txt", "text/plain")]
[InlineData("/sitemap.xml", "application/xml")]
public async Task Operational_endpoint_returns_expected_content_type(string path, string mediaType)
{
    var response = await _client.GetAsync(path);
    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    Assert.Equal(mediaType, response.Content.Headers.ContentType?.MediaType);
}

[Fact]
public async Task Home_page_contains_canonical_and_structured_contact()
{
    var html = await _client.GetStringAsync("/");
    Assert.Contains("rel=\"canonical\"", html);
    Assert.Contains("application/ld+json", html);
    Assert.Contains("ContactPage", html);
    Assert.Contains("king.huang@bakerhughes.com", html);
}
```

- [ ] **Step 1: Add the failing SEO and endpoint tests**

Create `SeoAndOperationalTests.cs` with assertions for canonical, description, Open Graph, structured data, `robots.txt`, `sitemap.xml`, `/health`, security headers, and a `404` response containing a link to `/`.

- [ ] **Step 2: Run the tests to verify failure**

```powershell
work/dotnet/dotnet.exe test tests/ConsolidatedMasoneilanContact.Tests
```

Expected: FAIL on SEO elements and missing endpoints.

- [ ] **Step 3: Implement request-aware absolute URLs**

Use forwarded headers in production and `request.Scheme + request.Host` to produce absolute URLs. The implementation must preserve path-base behavior and avoid hardcoding a domain.

- [ ] **Step 4: Implement the SEO partial**

Render title, description, canonical, Open Graph, Twitter card, and `application/ld+json` for `ContactPage`, `Person`, and `ContactPoint`. Serialize with `JsonSerializer` configured to escape HTML-sensitive characters.

- [ ] **Step 5: Implement the operational endpoints**

Map `/robots.txt` as `text/plain`, `/sitemap.xml` as application XML, and `/health` as a minimal JSON result. Include only `/` in the sitemap.

- [ ] **Step 6: Add security and status middleware**

Add `X-Content-Type-Options: nosniff`, `Referrer-Policy: strict-origin-when-cross-origin`, `X-Frame-Options: DENY`, a restrictive Content Security Policy compatible with local CSS/JS and inline structured data, HTTPS redirection outside Development, and a branded status-code page.

- [ ] **Step 7: Run the full test suite**

```powershell
work/dotnet/dotnet.exe test tests/ConsolidatedMasoneilanContact.Tests
```

Expected: all tests PASS.

- [ ] **Step 8: Commit SEO and operational behavior**

```powershell
git add src tests
git commit -m "feat: add search metadata and operational endpoints"
```

### Task 5: Implement the Industrial Responsive Visual System

**Files:**
- Read: `work/design/concept-hero.png`
- Read: `work/design/concept-page.png`
- Read: `docs/superpowers/plans/2026-10-31-design-system.md`
- Create: `src/ConsolidatedMasoneilanContact/wwwroot/css/site.css`
- Create: `src/ConsolidatedMasoneilanContact/wwwroot/js/site.js`
- Create: `src/ConsolidatedMasoneilanContact/wwwroot/images/valve-hero.webp`
- Create: `src/ConsolidatedMasoneilanContact/wwwroot/images/favicon.svg`
- Modify: Razor page and shared partials from Task 3.
- Test: `tests/ConsolidatedMasoneilanContact.Tests/StaticAssetTests.cs`

**Interfaces:**
- Consumes: accepted visual references and design system.
- Produces: one production CSS file, one progressively enhanced copy script, and local image assets.

**CSS tokens:**

```css
:root {
  --navy: #071d2b;
  --ink: #102733;
  --teal: #02bc94;
  --teal-deep: #018374;
  --paper: #f5f7f6;
  --white: #ffffff;
  --muted: #58707c;
  --line: #d9e1e3;
  --display: Georgia, "Noto Serif SC", "Songti SC", serif;
  --sans: "Segoe UI", "Microsoft YaHei", sans-serif;
  --container: 1180px;
}
```

- [ ] **Step 1: Add failing static asset tests**

Assert that `/css/site.css`, `/js/site.js`, `/images/valve-hero.webp`, and `/images/favicon.svg` return `200`, and that the home page references all four.

- [ ] **Step 2: Run the static asset tests to verify failure**

```powershell
work/dotnet/dotnet.exe test tests/ConsolidatedMasoneilanContact.Tests --filter Static
```

Expected: FAIL with `404` for missing assets.

- [ ] **Step 3: Produce the final hero asset**

Using the selected official hero scene as reference, create a local WebP crop for web use. Keep it photographic, color-consistent, and free of invented logos or text. Record its native dimensions.

- [ ] **Step 4: Implement the layout and responsive states**

Implement the accepted hero split, brand editorial band, contact panel, and footer. Add breakpoints for 1024px, 760px, and 520px, plus:

```css
@media (prefers-reduced-motion: reduce) {
  *, *::before, *::after {
    scroll-behavior: auto !important;
    animation-duration: 0.01ms !important;
    animation-iteration-count: 1 !important;
    transition-duration: 0.01ms !important;
  }
}

:focus-visible {
  outline: 3px solid #f0b37e;
  outline-offset: 4px;
}
```

- [ ] **Step 5: Implement accessible copy controls**

Add copy buttons with `data-copy-value`. On success, update the visible state, change the icon to a check, and announce “已复制电话号码” or “已复制邮箱地址” through an `aria-live="polite"` region. On failure, select the displayed contact text and announce that manual copying is required.

- [ ] **Step 6: Run the full test suite**

```powershell
work/dotnet/dotnet.exe test tests/ConsolidatedMasoneilanContact.Tests
```

Expected: all tests PASS.

- [ ] **Step 7: Commit the visual system**

```powershell
git add src tests
git commit -m "feat: implement industrial contact page design"
```

### Task 6: Verify the Rendered Site and Add Deployment Documentation

**Files:**
- Create: `README.md`
- Create: `DEPLOYMENT.md`
- Create: `work/qa/desktop.png`
- Create: `work/qa/mobile.png`
- Modify: implementation files only when QA finds concrete drift.

**Interfaces:**
- Consumes: the accepted concept images, latest browser screenshots, and the runnable app.
- Produces: verified implementation evidence and deployment instructions for an eventual domain/server.

**QA commands:**

```powershell
$env:ASPNETCORE_URLS = "http://127.0.0.1:5187"
work/dotnet/dotnet.exe run --project src/ConsolidatedMasoneilanContact
```

- [ ] **Step 1: Run the app and test the core contact path**

Open `/`, follow “产品品牌” and “联系方式”, click the phone and email links to inspect their targets, and test both copy controls with keyboard and pointer input.

- [ ] **Step 2: Capture desktop and mobile screenshots**

Capture at `1440x1000` and `390x844`, storing them in `work/qa/desktop.png` and `work/qa/mobile.png`.

- [ ] **Step 3: Compare accepted concept and implementation**

Compare `work/design/reference-valves-home.png`, the recorded DOM evidence, `work/qa/desktop.png`, and `work/qa/mobile.png`. If native image inspection is unavailable, document that limitation and use browser accessibility snapshots, computed layout boxes, screenshot dimensions, and DOM style checks as evidence. Inspect at least copy, layout, typography, palette, image treatment, spacing, container model, and responsive behavior. Fix every material mismatch and recapture.

- [ ] **Step 4: Validate SEO output**

Inspect rendered HTML for title, description, canonical, Open Graph, valid JSON-LD, the exact contact values, and the sitemap/robots output.

- [ ] **Step 5: Write deployment documentation**

Document local run, `dotnet publish`, IIS or Linux reverse-proxy deployment, HTTPS, forwarded headers, domain setup, search-engine submission, and mainland-China ICP review. Clearly state that public indexing begins only after domain/hosting launch and verification.

- [ ] **Step 6: Run final verification**

```powershell
work/dotnet/dotnet.exe build ConsolidatedMasoneilanContact.sln --configuration Release
work/dotnet/dotnet.exe test tests/ConsolidatedMasoneilanContact.Tests --configuration Release
work/dotnet/dotnet.exe publish src/ConsolidatedMasoneilanContact --configuration Release --output work/publish
```

Expected: build and tests pass; publish output is created without secrets or development-only artifacts.

- [ ] **Step 7: Commit the verified site**

```powershell
git add README.md DEPLOYMENT.md src tests
git commit -m "docs: add deployment and SEO launch guidance"
```

## Self-Review

- [x] The Chinese-only site, exact contact details, and China-focused audience map to Tasks 3–4.
- [x] Visual concept, responsive layout, image treatment, copy, and icon behavior map to Tasks 1, 3, and 5.
- [x] Canonical, structured data, sitemap, robots, security headers, 404, and health behavior map to Task 4.
- [x] Accessibility, reduced motion, copy feedback, and browser verification map to Tasks 5–6.
- [x] Build, tests, publish, local screenshots, and deployment guidance map to Task 6.
- [x] No domain-dependent claim is treated as immediately achievable; launch and indexing requirements are explicitly documented.
