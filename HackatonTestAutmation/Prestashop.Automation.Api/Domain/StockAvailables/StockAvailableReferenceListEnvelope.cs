namespace Prestashop.Automation.Api.Domain.StockAvailables;

[XmlRoot("prestashop")]
public sealed class StockAvailableReferenceListEnvelope
{
    [XmlElement("stock_availables")]
    public StockAvailableReferenceCollectionDto StockAvailables { get; set; } = new();
}

public sealed class StockAvailableReferenceCollectionDto
{
    [XmlElement("stock_available")]
    public List<StockAvailableReferenceDto> Items { get; set; } = [];
}

public sealed class StockAvailableReferenceDto
{
    [XmlAttribute("id")]
    public string AttributeId { get; set; } = string.Empty;

    [XmlElement("id")]
    public int ElementId { get; set; }

    public int ResolveId()
    {
        if (ElementId > 0)
        {
            return ElementId;
        }

        return int.TryParse(AttributeId, out var parsed) ? parsed : 0;
    }
}
