using Newtonsoft.Json;

namespace IntegracaoSistemasSoftwareTrabalho1BIM.Entities.Yelp;

public class Business
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("url")]
    public string Url { get; set; }
    [JsonProperty("rating")]
    public string Rating { get; set; }
    [JsonProperty("location")]
    public Address Addresses { get; set; }
    [JsonProperty("phone")]
    public string Phone { get; set; }
    
}