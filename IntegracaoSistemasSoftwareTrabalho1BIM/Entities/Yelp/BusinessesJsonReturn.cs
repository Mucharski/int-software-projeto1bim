using Newtonsoft.Json;

namespace IntegracaoSistemasSoftwareTrabalho1BIM.Entities.Yelp;

public class BusinessesJsonReturn
{
    [JsonProperty("businesses")]
    public List<Business> Businesses { get; set; }
}