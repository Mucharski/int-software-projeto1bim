using IntegracaoSistemasSoftwareTrabalho1BIM.Data;
using IntegracaoSistemasSoftwareTrabalho1BIM.Data.Models;
using IntegracaoSistemasSoftwareTrabalho1BIM.Entities.Yelp;
using IntegracaoSistemasSoftwareTrabalho1BIM.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IntegracaoSistemasSoftwareTrabalho1BIM.Repositories;

public class RestaurantRepository : IRestaurantRepository
{
    private readonly Context _context;

    public RestaurantRepository(Context context)
    {
        _context = context;
    }

    public async Task CreateRestaurants(BusinessesJsonReturn restaurants)
    {
        foreach (var restaurant in restaurants.Businesses)
        {
            var model = new RestaurantModel(restaurant);
            
            await _context.Restaurants.AddAsync(model);
        }

        await _context.SaveChangesAsync();

    }

    public List<RestaurantModel> List()
    {
        return _context.Restaurants.Include(a => a.Addresses).ToList();
    }
}