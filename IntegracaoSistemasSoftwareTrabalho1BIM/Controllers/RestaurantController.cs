using IntegracaoSistemasSoftwareTrabalho1BIM.Repositories.Interfaces;
using IntegracaoSistemasSoftwareTrabalho1BIM.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IntegracaoSistemasSoftwareTrabalho1BIM.Controllers;

[ApiController]
[Route("[controller]")]
public class RestaurantController : ControllerBase
{
    private readonly IRestaurantService _restaurantService;

    public RestaurantController(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }
    
    [HttpGet]
    [Route("BestRestaurants")]
    public async Task<IActionResult> GetBestRestaurants([FromQuery] string location)
    {
        await _restaurantService.InitializeRestaurants(location);
        
        return Ok("Selecionado os 5 melhores restaurantes de acordo com a Yelp e salvos com sucesso!");
    }
    
    [HttpGet]
    [Route("List")]
    public async Task<IActionResult> ListRestaurants()
    {
        var restaurants = await _restaurantService.ListRestaurants();
        
        return Ok(restaurants);
    }
}