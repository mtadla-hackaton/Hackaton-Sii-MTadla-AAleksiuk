using System.Xml;

namespace Prestashop.Automation.Api.Domain.StockAvailables;

[XmlRoot("prestashop")]
public sealed class StockAvailableEnvelope
{
    [XmlElement("stock_available")]
    public StockAvailableDto StockAvailable { get; set; } = new();
}

public sealed class StockAvailableDto
{
    [XmlElement("id")]
    public int Id { get; set; }

    [XmlElement("id_product")]
    public int ProductId { get; set; }

    [XmlElement("id_product_attribute")]
    public int ProductAttributeId { get; set; }

    [XmlElement("id_shop")]
    public int ShopId { get; set; }

    [XmlElement("id_shop_group")]
    public int ShopGroupId { get; set; }

    [XmlElement("quantity")]
    public int Quantity { get; set; }

    [XmlAnyElement]
    public XmlElement[] OtherElements { get; set; } = [];
}
