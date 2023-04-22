using Newtonsoft.Json;

namespace IntegracaoSistemasSoftwareTrabalho1BIM.Entities.Yelp;

public class Address
{
    [JsonProperty("address1")]
    public string MainAddress { get; set; }
    [JsonProperty("address2")]
    public string SecondaryAddress { get; set; }
    [JsonProperty("city")]
    public string City { get; set; }
    [JsonProperty("zip_code")]
    public string ZipCode { get; set; }
    [JsonProperty("country")]
    public string Country { get; set; }
    [JsonProperty("state")]
    public string State { get; set; }
}