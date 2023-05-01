using IntegracaoSistemasSoftwareTrabalho1BIM.Data.Models;
using IntegracaoSistemasSoftwareTrabalho1BIM.Entities.Yelp;
using IntegracaoSistemasSoftwareTrabalho1BIM.Repositories.Interfaces;
using IntegracaoSistemasSoftwareTrabalho1BIM.Services.Interfaces;

namespace IntegracaoSistemasSoftwareTrabalho1BIM.Services;

public class RestaurantService : IRestaurantService
{
    private readonly IRestaurantRepository _repository;
    private readonly IYelpRepository _yelpRepository;

    public RestaurantService(IRestaurantRepository repository, IYelpRepository yelpRepository)
    {
        _repository = repository;
        _yelpRepository = yelpRepository;
    }

    public async Task InitializeRestaurants(string location)
    {
        BusinessesJsonReturn restaurants = await _yelpRepository.ListRestaurants(location);

        await CreateRestaurants(restaurants);
    }

    public async Task<List<RestaurantModel>> ListRestaurants()
    {
        return _repository.List();
    }

    public Task<int> EditRestaurant(int id, string name, string phone)
    {
        RestaurantModel model = new() {Id = id, Name = name, Phone = phone};
        
        return _repository.Edit(model);
    }

    public async Task DeleteRestaurant(int id)
    {
        await _repository.Delete(id);
    }

    private async Task CreateRestaurants(BusinessesJsonReturn restaurants)
    {
        await _repository.CreateRestaurants(restaurants);
    }
    
}