namespace ConsolidatedMasoneilanContact.Models;

public sealed record BrandProfile(
    string Number,
    string Name,
    string ChineseName,
    string ProductLabel,
    string Description,
    string ImagePath,
    string ImageAlt,
    int ImageWidth,
    int ImageHeight);

public sealed record SiteContent(
    string Title,
    string Description,
    string HeroBrandLine,
    string HeroHeading,
    string HeroSummary,
    string BrandSectionLabel,
    string BrandSectionTitle,
    string BrandSectionSummary,
    IReadOnlyList<BrandProfile> Brands,
    string ContactSectionLabel,
    string ContactHeading,
    string ContactSummary,
    string FooterNote,
    string OfficialSiteUrl,
    SalesContact Contact);
