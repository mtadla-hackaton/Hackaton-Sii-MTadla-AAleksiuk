using Prestashop.Automation.Core.Constants;

namespace Prestashop.Automation.Api.Domain.Product;

public class CreateProductRequest
{
    public required string Name { get; init; }
    public required string Slug { get; init; }
    public decimal Price { get; init; }
    public int DefaultCategoryId { get; init; }
    public int DefaultShopId { get; init; }
    public int TaxRulesGroupId { get; init; }
    public int AvailableForOrder { get; init; } = TestDataConstants.Product.AvailableForOrder;
    public string Visibility { get; init; } = TestDataConstants.Product.VisibleInCatalogAndSearch;
    public int ShowPrice { get; init; } = TestDataConstants.Product.ShowPrice;
    public int MinimalQuantity { get; init; } = TestDataConstants.Product.MinimalQuantity;
}

[XmlRoot("prestashop")]
public class ProductCreateEnvelope
{
    [XmlElement("product")]
    public ProductCreateDto Product { get; set; } = new();
}

public class ProductCreateDto
{
    [XmlElement("id_category_default")]
    public int DefaultCategoryId { get; set; }

    [XmlElement("id_tax_rules_group")]
    public int TaxRulesGroupId { get; set; }

    [XmlElement("id_shop_default")]
    public int DefaultShopId { get; set; }

    [XmlElement("active")]
    public int Active { get; set; }

    [XmlElement("state")]
    public int State { get; set; }

    [XmlElement("price")]
    public decimal Price { get; set; }

    [XmlElement("available_for_order")]
    public int AvailableForOrder { get; set; }

    [XmlElement("visibility")]
    public string Visibility { get; set; } = "both";

    [XmlElement("show_price")]
    public int ShowPrice { get; set; }

    [XmlElement("minimal_quantity")]
    public int MinimalQuantity { get; set; }

    [XmlElement("name")]
    public ProductLocalizedFieldCreateDto Name { get; set; } = new();

    [XmlElement("link_rewrite")]
    public ProductLocalizedFieldCreateDto LinkRewrite { get; set; } = new();

    [XmlElement("associations")]
    public ProductAssociationsCreateDto Associations { get; set; } = new();
}

public class ProductLocalizedFieldCreateDto
{
    [XmlElement("language")]
    public List<ProductLanguageCreateDto> Languages { get; set; } = [];
}

public class ProductLanguageCreateDto
{
    [XmlAttribute("id")]
    public int Id { get; set; }

    [XmlText]
    public string Value { get; set; } = string.Empty;
}

public class ProductAssociationsCreateDto
{
    [XmlArray("categories")]
    [XmlArrayItem("category")]
    public List<ProductCategoryCreateDto> Categories { get; set; } = [];
}

public class ProductCategoryCreateDto
{
    [XmlElement("id")]
    public int Id { get; set; }
}
