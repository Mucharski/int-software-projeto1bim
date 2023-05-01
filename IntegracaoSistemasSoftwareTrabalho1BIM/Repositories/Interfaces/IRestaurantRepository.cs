using IntegracaoSistemasSoftwareTrabalho1BIM.Data.Models;
using IntegracaoSistemasSoftwareTrabalho1BIM.Entities.Yelp;

namespace IntegracaoSistemasSoftwareTrabalho1BIM.Repositories.Interfaces;

public interface IRestaurantRepository
{
    public Task CreateRestaurants(BusinessesJsonReturn restaurants);
    public List<RestaurantModel> List();
    public Task<int> Edit(RestaurantModel restaurant);
    public Task Delete(int id);
}