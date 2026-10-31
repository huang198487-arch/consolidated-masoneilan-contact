# Consolidated and Masoneilan Contact Page Design System

## Reference Evidence

- Public source: `https://valves.bakerhughes.com/`
- Captured viewport: `work/design/reference-valves-home.png`
- Computed style evidence: `work/design/reference-styles.json`
- Public media evidence: `work/design/reference-media.json`
- Reference viewport examined: 1021 CSS pixels wide

The model runtime used for this build could not open the captured images directly. Browser accessibility snapshots, screenshot dimensions, computed typography, spacing boxes, and public CSS colors are the recorded visual evidence.

## Visual Character

The reference combines a quiet white global navigation bar with large, dark photographic valve imagery. Teal is the strongest brand accent, while type remains restrained and the layout uses broad horizontal bands rather than nested cards. The contact site keeps that established industrial character while making the sales route more immediate.

## Color Tokens

| Token | Value | Use |
| --- | --- | --- |
| Navy | `#071D2B` | Hero background, contact panel |
| Ink | `#102733` | Primary text |
| Teal | `#02BC94` | Primary action, active line, key accent |
| Deep teal | `#018374` | Hover and secondary accent |
| White | `#FFFFFF` | Header, page surfaces |
| Cool white | `#F5F7F6` | Brand and contact section background |
| Muted ink | `#58707C` | Secondary body text |
| Border | `#D9E1E3` | Rules, dividers, input-like surfaces |

## Typography

- Display: `Georgia, "Noto Serif SC", "Songti SC", serif` for the main Chinese headline.
- Interface/body: `Segoe UI, "Microsoft YaHei", "Noto Sans SC", sans-serif`.
- Hero title: `clamp(3rem, 6vw, 6.6rem)`, line-height `0.98`, regular weight.
- Section title: `clamp(2rem, 4vw, 3.75rem)`, line-height `1.08`.
- Lead body: `clamp(1.05rem, 1.65vw, 1.35rem)`, line-height `1.75`.
- Utility/navigation: `0.82rem`, weight `600`, letter spacing `0.08em`.
- Buttons: minimum `1rem`, weight `650`, no browser-default typography.

## Layout

- Maximum content width: `1180px`.
- Desktop outer gutter: `32px`.
- Mobile outer gutter: `20px`.
- Large section spacing: `clamp(72px, 10vw, 144px)`.
- Hero height: at least `min(780px, calc(100svh - 88px))`, with content kept above the fold on a small laptop.
- Header height: `72px` desktop, `64px` mobile.
- Hero composition: content left aligned over a photographic valve scene, with the contact action visible in the first viewport.
- Brand section: open two-column editorial comparison separated by a vertical rule, not a card grid.
- Contact section: one strong navy panel with a teal action rail.
- Footer: short, low-density closing band.

## Component Families

- Primary button: solid teal, white label, square-ish `2px` radius, minimum height `50px`.
- Secondary button: transparent with white border on navy or ink border on light surfaces.
- Outline link: uppercase-style Chinese utility label with a small SVG arrow.
- Contact row: label, large copyable value, and a compact copy button with consistent icon treatment.
- Brand item: oversized brand name, short description, thin numeric rule.

## Imagery

- Use a locally hosted Baker Hughes Valves public product scene.
- Preserve sharp industrial detail and natural image color.
- Use a directional navy gradient only where needed to keep text readable.
- No glass cards over the image, no color tint unrelated to the reference, and no decorative particles.

## Iconography

- Inline SVG only; use `24px` viewBox with `1.75` stroke width.
- Icons: phone, email, copy, check, arrow.
- Rounded line caps; icons optically centered inside `40px` square hit areas.

## Motion

- Hero copy and action fade upward once on first paint.
- Copy button changes to a check and announces success.
- Hover movement is capped at `2px`.
- All entrance and transition duration resolves to near-zero under `prefers-reduced-motion`.

## Responsive Rules

- At `1024px`: reduce hero type and shift the image focal point; brand columns remain two-up.
- At `760px`: collapse navigation into a compact two-link row, stack brand content, reduce section spacing.
- At `520px`: single-column contact values, full-width action buttons, minimum `44px` touch targets, no horizontal overflow.
