using IntegracaoSistemasSoftwareTrabalho1BIM.Entities.Yelp;

namespace IntegracaoSistemasSoftwareTrabalho1BIM.Data.Models;

public class RestaurantModel
{
    public RestaurantModel(){}
    
    public RestaurantModel(Business restaurant)
    {
        YelpId = restaurant.Id;
        Name = restaurant.Name;
        Url = restaurant.Url;
        Rating = restaurant.Rating;
        Phone = restaurant.Phone;

        Addresses = new List<AddressModel>
        {
            new ()
            {
                Address = restaurant.Addresses.MainAddress,
                Country = restaurant.Addresses.Country,
                City = restaurant.Addresses.City,
                State = restaurant.Addresses.State,
                ZipCode = restaurant.Addresses.ZipCode,
            }
        };
    }
    public int Id { get; set; }
    public string YelpId { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string Rating { get; set; }
    public string Phone { get; set; }
    
    public ICollection<AddressModel> Addresses { get; set; }

}