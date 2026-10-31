namespace ConsolidatedMasoneilanContact.Models;

public static class SiteContentCatalog
{
    public static SiteContent Chinese { get; } = new(
        Title: "康索尼德与梅索尼兰销售联系方式 | 黄海宏 | Baker Hughes",
        Description: "查找康索尼德（Consolidated）安全泄压阀与梅索尼兰（Masoneilan）控制阀销售联系方式。联系人黄海宏，电话 18001547123，邮箱 king.huang@bakerhughes.com。",
        HeroBrandLine: "CONSOLIDATED  /  MASONEILAN",
        HeroHeading: "可靠阀门方案，从一次直接沟通开始",
        HeroSummary: "面向中国客户，提供 Consolidated 安全泄压阀与 Masoneilan 控制阀及仪表产品咨询。",
        BrandSectionLabel: "01 / 产品品牌",
        BrandSectionTitle: "两套阀门技术，一个直接联系入口",
        BrandSectionSummary: "围绕压力保护与过程控制需求，连接贝克休斯旗下两个阀门品牌的产品沟通渠道。",
        Brands:
        [
            new BrandProfile(
                Number: "01",
                Name: "Consolidated",
                ChineseName: "康索尼德",
                ProductLabel: "安全泄压阀",
                Description: "聚焦压力保护应用，为流程工业中的设备与系统提供安全泄压阀产品沟通与选型支持。",
                ImagePath: "/images/valve-hero.jpg",
                ImageAlt: "Consolidated 安全泄压阀产品场景"),
            new BrandProfile(
                Number: "02",
                Name: "Masoneilan",
                ChineseName: "梅索尼兰",
                ProductLabel: "控制阀及仪表",
                Description: "面向过程控制场景，提供控制阀与仪表产品沟通，帮助客户对接具体工况与应用需求。",
                ImagePath: "/images/masoneilan-banner.jpg",
                ImageAlt: "Masoneilan 控制阀产品场景")
        ],
        ContactSectionLabel: "02 / 销售联系",
        ContactHeading: "直接联系销售",
        ContactSummary: "如需了解相关产品，或希望进一步沟通具体应用，请通过电话或邮件联系黄海宏。",
        FooterNote: "Consolidated 与 Masoneilan 为贝克休斯旗下阀门品牌。",
        Contact: new SalesContact(
            Name: "黄海宏",
            Role: "销售联系人",
            DisplayPhone: "18001547123",
            PhoneUri: "tel:+8618001547123",
            Email: "king.huang@bakerhughes.com"));
}
