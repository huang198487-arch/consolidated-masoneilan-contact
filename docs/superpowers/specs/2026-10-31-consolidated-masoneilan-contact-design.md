# Consolidated and Masoneilan Sales Contact Site

## Purpose

Create a public, search-engine-readable Chinese sales contact website for customers looking for Baker Hughes' Consolidated and Masoneilan brands in China. The site must make the sales contact obvious, trustworthy, and immediately actionable on desktop and mobile.

The primary contact is:

- Name: 黄海宏
- Phone: 18001547123
- Email: king.huang@bakerhughes.com

## Success Criteria

- A visitor can identify the two represented product brands within the first viewport.
- A visitor can call or email 黄海宏 in one click or copy either contact detail.
- The complete customer-facing experience is available in Simplified Chinese.
- Search engines receive descriptive Chinese page titles, descriptions, canonical URLs, structured data, `robots.txt`, and `sitemap.xml`.
- The page remains readable and usable at desktop, tablet, and mobile widths.
- The application builds, serves successfully, and passes automated and browser checks.

## Scope

### Included

- A Chinese, single-page-style public website.
- The primary page route is `/`.
- Brand introduction for Consolidated and Masoneilan.
- A prominent sales contact section for 黄海宏.
- One-click phone and email actions plus copy controls.
- Search metadata, social sharing metadata, structured data, sitemap, and robots configuration.
- Responsive layout, accessible keyboard behavior, reduced-motion support, and basic security headers.
- Automated integration tests and browser-based visual verification.

### Excluded

- User accounts, authentication, a database, or a contact form.
- Analytics, advertising pixels, live chat, or third-party tracking.
- Claims about regional offices, response times, certifications, or product availability that the user has not supplied.
- Public deployment and search-engine submission until a domain and hosting are chosen.

## Information Architecture

Both language routes use the same content sequence:

1. Header with brand wordmark, brand navigation, contact navigation, and language switch.
2. Hero introducing the two represented Baker Hughes brands and the sales contact path.
3. Brand section with one concise introduction each for Consolidated and Masoneilan.
4. Contact section with 黄海宏's name, phone, email, and primary call/email actions.
5. Short footer identifying the represented brands and repeating the contact route.

The contact section is linked from the header and remains easy to find while scrolling.

## Content

The contact information and customer value proposition are fixed by the user's brief. Product descriptions remain conservative:

- Consolidated: safety relief valve products.
- Masoneilan: control valve and instrumentation products.
- The site must not invent a job title, office address, business hours, response-time promise, or local inventory claim.

All customer-facing copy must be written in natural, professional Simplified Chinese.

## Visual Direction

The design uses an industrial editorial style with a true deep navy background, white and cool-neutral surfaces, and restrained warm copper accents. It should feel established and technical rather than like a generic card-based SaaS template.

Key visual rules:

- Strong typographic hierarchy using a serif display face supported by a clean Chinese sans-serif body face.
- An image-led hero with a purpose-built industrial valve scene, integrated without a color wash.
- Open bands and editorial split layouts instead of nested cards or repeated generic feature grids.
- A single contact panel that visually anchors the lower half of the page.
- Thin technical rules and a subtle product-drawing motif as the signature decorative language.
- Motion limited to restrained entrance and contact-copy feedback, disabled under `prefers-reduced-motion`.

## Design System

- Colors: deep navy `#071D2B`, ink `#102733`, copper `#B87945`, cool white `#F5F7F6`, muted ink `#58707C`, and border `#D9E1E3`.
- Display typography: local-safe serif stack with no external font dependency for the initial build.
- UI typography: Segoe UI and Chinese system sans-serif fallback.
- Spacing: an 8px-based scale with generous section rhythms.
- Radii: restrained, with primarily square or lightly rounded media and controls.
- Buttons: solid copper primary and outlined navy secondary with explicit focus states.
- Icons: custom inline SVG arrows, phone, email, copy, check, and language controls with consistent stroke weight.

## Architecture

The site is an ASP.NET Core 10 Razor Pages application using the modern `WebApplicationBuilder` and `WebApplication` hosting model.

Primary components:

- Razor Pages for the Chinese public route.
- A shared layout and partials for metadata, header, footer, and contact presentation.
- Minimal endpoints for `robots.txt`, `sitemap.xml`, and `/health`.
- Static production assets under `wwwroot`.
- No database and no server-side mutable state.

The Chinese page at `/` is the canonical indexable URL.

## SEO

Each page supplies:

- A unique title and meta description containing the represented brands and sales contact intent.
- One clear H1 and a semantic heading sequence.
- Canonical absolute URL derived from the active public request host and forwarded headers.
- Open Graph and Twitter card metadata.
- `ContactPage` and `Person` structured data containing the supplied name and contact methods.
- Crawlable phone and email values in the rendered HTML.

Site-wide endpoints:

- `/robots.txt` allows crawling and references `/sitemap.xml`.
- `/sitemap.xml` lists the canonical Chinese page using the active public host.

Indexing and ranking are not guaranteed. Search-engine account verification and submission become possible only after a public domain is available.

## Interaction and Error Handling

- Phone controls use `tel:+8618001547123`.
- Email controls use `mailto:king.huang@bakerhughes.com`.
- Copy controls use the browser Clipboard API and announce success or failure through an accessible live region.
- Clipboard rejection or unavailability falls back to selecting the displayed text and clearly instructs the visitor to copy manually.
- Navigation uses ordinary links so it works without JavaScript.
- The health endpoint returns `200` with a minimal JSON payload and no sensitive diagnostics.
- Unknown routes render a branded `404` page with links back to the contact route.

## Security and Operations

- Enforce HTTPS outside development.
- Add conservative security headers without breaking the static site.
- Do not commit secrets. The app requires none for its base functionality.
- Use forwarded headers so canonical URLs and sitemap links remain correct behind a trusted reverse proxy.
- Provide deployment documentation for IIS or a Linux reverse proxy, and document domain/configuration steps separately.

## Accessibility and Performance

- Maintain WCAG AA color contrast for text and controls.
- Provide skip navigation, visible keyboard focus, semantic landmarks, and descriptive link/button labels.
- Respect reduced-motion preferences.
- Keep above-the-fold assets locally hosted and dimensioned to prevent layout shift.
- Use compiled static CSS and avoid client framework payloads.
- Target strong Lighthouse scores for accessibility, best practices, and SEO.

## Testing

### Automated Integration Tests

- The Chinese route returns `200`.
- Chinese titles, descriptions, H1s, and canonical URLs are present.
- Phone, email, and structured data contain the supplied contact information.
- `robots.txt` and `sitemap.xml` return valid content types and expected URLs.
- `/health` returns `200`.
- HTTP security headers are present.
- Unknown routes return the branded `404` response.

### Browser Verification

- Verify desktop and mobile first viewports.
- Check navigation, language switch, call/email links, and copy controls.
- Compare the accepted design concept against the latest browser screenshot.
- Confirm no horizontal overflow, clipped text, missing assets, or browser-default control typography.

## Acceptance

The project is complete when it builds without warnings that affect delivery, all integration tests pass, the public pages work in a browser at desktop and mobile widths, and the implementation matches the accepted visual concept. Deployment remains pending until the owner provides a domain and hosting target.
