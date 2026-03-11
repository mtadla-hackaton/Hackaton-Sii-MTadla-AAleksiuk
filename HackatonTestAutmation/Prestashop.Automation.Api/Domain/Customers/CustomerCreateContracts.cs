namespace Prestashop.Automation.Api.Domain.Customers;

public class CreateCustomerRequest
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public int DefaultGroupId { get; init; }
    public int LanguageId { get; init; }
    public string FullName => $"{FirstName} {LastName}";
}

[XmlRoot("prestashop")]
public class CustomerCreateEnvelope
{
    [XmlElement("customer")]
    public CustomerCreateDto Customer { get; set; } = new();
}

public class CustomerCreateDto
{
    [XmlElement("firstname")]
    public string FirstName { get; set; } = string.Empty;

    [XmlElement("lastname")]
    public string LastName { get; set; } = string.Empty;

    [XmlElement("email")]
    public string Email { get; set; } = string.Empty;

    [XmlElement("passwd")]
    public string Password { get; set; } = string.Empty;

    [XmlElement("id_default_group")]
    public int DefaultGroupId { get; set; }

    [XmlElement("id_lang")]
    public int LanguageId { get; set; }

    [XmlElement("active")]
    public int Active { get; set; }

    [XmlElement("newsletter")]
    public int Newsletter { get; set; }

    [XmlElement("optin")]
    public int OptIn { get; set; }

    [XmlElement("associations")]
    public CustomerAssociationsCreateDto Associations { get; set; } = new();
}

public class CustomerAssociationsCreateDto
{
    [XmlArray("groups")]
    [XmlArrayItem("group")]
    public List<CustomerGroupCreateDto> Groups { get; set; } = [];
}

public class CustomerGroupCreateDto
{
    [XmlElement("id")]
    public int Id { get; set; }
}
