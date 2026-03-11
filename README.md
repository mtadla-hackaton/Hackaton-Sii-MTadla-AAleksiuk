# Hackaton-Sii-MTadla-AAleksiuk

## Prestashop API Key Configuration

Add `Prestashop:ApiKey` to the following projects:

- `Prestashop.Tests.UI`
- `Prestashop.Tests.Api`

### Steps

1. Right-click the project in Visual Studio.
2. Select **Manage User Secrets**.
3. Add the following configuration:

```json
{
  "Prestashop:ApiKey": "valid-prestashop-api-key"
}
```