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

    public async Task<int> Edit(RestaurantModel restaurant)
    {
        var entity = await _context.Restaurants.FindAsync(restaurant.Id);

        if (entity == null)
        {
            return 0;
        }

        entity.Name = restaurant.Name == null ? entity.Name : restaurant.Name;
        entity.Phone = restaurant.Phone == null ? entity.Phone : restaurant.Phone;

        await _context.SaveChangesAsync();

        return 1;
    }

    public async Task Delete(int id)
    {
        RestaurantModel restaurantModel = new (){Id = id};  
        
        _context.Restaurants.Entry(restaurantModel).State = EntityState.Deleted;  
        
        await _context.SaveChangesAsync();   
    }
}