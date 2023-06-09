using IntegracaoSistemasSoftwareTrabalho1BIM.Data.Models;
using IntegracaoSistemasSoftwareTrabalho1BIM.Entities.Yelp;

namespace IntegracaoSistemasSoftwareTrabalho1BIM.Services.Interfaces;

public interface IRestaurantService
{
    public Task InitializeRestaurants(string location);
    public Task<List<RestaurantModel>> ListRestaurants();
    public Task<int> EditRestaurant(int id, string name, string phone);
    public Task DeleteRestaurant(int id);
    public void SendNewRestaurantsToQueue(BusinessesJsonReturn restaurants);
}