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
    }
}