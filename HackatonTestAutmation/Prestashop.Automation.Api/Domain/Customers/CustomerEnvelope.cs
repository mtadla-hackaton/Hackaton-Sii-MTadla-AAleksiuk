namespace Prestashop.Automation.Api.Domain.Customers;

[XmlRoot("prestashop")]
public class CustomerEnvelope
{
    [XmlElement("customer")]
    public CustomerDto Customer { get; set; } = new();
}

public class CustomerDto
{
    [XmlElement("id")]
    public int? Id { get; set; }

    [XmlElement("firstname")]
    public string FirstName { get; set; } = string.Empty;

    [XmlElement("lastname")]
    public string LastName { get; set; } = string.Empty;

    [XmlElement("email")]
    public string Email { get; set; } = string.Empty;

    [XmlElement("active")]
    public int? Active { get; set; }
}
