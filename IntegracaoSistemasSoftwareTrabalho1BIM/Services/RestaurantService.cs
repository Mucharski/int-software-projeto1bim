using System.Text;
using IntegracaoSistemasSoftwareTrabalho1BIM.Data.Models;
using IntegracaoSistemasSoftwareTrabalho1BIM.Entities.Yelp;
using IntegracaoSistemasSoftwareTrabalho1BIM.Repositories.Interfaces;
using IntegracaoSistemasSoftwareTrabalho1BIM.Services.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;

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

        SendNewRestaurantsToQueue(restaurants);
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

    public void SendNewRestaurantsToQueue(BusinessesJsonReturn restaurants)
    {
        var factory = new ConnectionFactory { HostName = "localhost" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "new-restaurants",
            durable: false,
            exclusive: false,
            autoDelete: false);

        foreach (var restaurant in restaurants.Businesses)
        {
            var model = new RestaurantModel(restaurant);
            
            string message = JsonConvert.SerializeObject(model);

            var body = Encoding.UTF8.GetBytes(message);
        
            channel.BasicPublish(exchange: string.Empty,
                routingKey: "new-restaurants",
                basicProperties: null,
                body: body);
        }

        Console.WriteLine($"Mensagem enviada!");
    }

    private async Task CreateRestaurants(BusinessesJsonReturn restaurants)
    {
        await _repository.CreateRestaurants(restaurants);
    }
    
}