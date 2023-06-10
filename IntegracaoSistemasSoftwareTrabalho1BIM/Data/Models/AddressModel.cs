using Newtonsoft.Json;

namespace IntegracaoSistemasSoftwareTrabalho1BIM.Data.Models;

public class AddressModel
{
    public int Id { get; set; }
    
    [JsonIgnore]
    public RestaurantModel Restaurant { get; set; }
    public int RestaurantId { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
}