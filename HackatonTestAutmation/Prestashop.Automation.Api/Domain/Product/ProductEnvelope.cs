using System.Xml;

namespace Prestashop.Automation.Api.Domain.Product;

[XmlRoot("prestashop")]
public class ProductEnvelope
{
    [XmlElement("product")]
    public ProductDto Product { get; set; } = new();
}

public class ProductDto
{
    [XmlElement("id")]
    public int? Id { get; set; }

    [XmlElement("id_category_default")]
    public int? DefaultCategoryId { get; set; }

    [XmlElement("id_tax_rules_group")]
    public int? TaxRulesGroupId { get; set; }

    [XmlElement("id_shop_default")]
    public int? DefaultShopId { get; set; }

    [XmlElement("active")]
    public int? Active { get; set; }

    [XmlElement("state")]
    public int? State { get; set; }

    [XmlElement("price")]
    public decimal? Price { get; set; }

    [XmlElement("name")]
    public LocalizedFieldDto Name { get; set; } = new();

    [XmlElement("link_rewrite")]
    public LocalizedFieldDto LinkRewrite { get; set; } = new();

    [XmlAnyElement]
    public XmlElement[] OtherElements { get; set; } = [];
}

public class LocalizedFieldDto
{
    [XmlElement("language")]
    public List<LanguageValueDto> Languages { get; set; } = [];
}

public class LanguageValueDto
{
    [XmlAttribute("id")]
    public string Id { get; set; } = string.Empty;

    [XmlText]
    public string Value { get; set; } = string.Empty;
}
