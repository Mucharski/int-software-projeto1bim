using IntegracaoSistemasSoftwareTrabalho1BIM.Data.Models;

namespace IntegracaoSistemasSoftwareTrabalho1BIM.Services.Interfaces;

public interface IRestaurantService
{
    public Task InitializeRestaurants(string location);
    public Task<List<RestaurantModel>> ListRestaurants();
}