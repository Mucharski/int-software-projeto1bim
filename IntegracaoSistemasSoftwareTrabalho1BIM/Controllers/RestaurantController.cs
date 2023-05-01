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
    
    [HttpPut]
    [Route("Restaurant")]
    public async Task<IActionResult> EditRestaurant([FromQuery] int restaurantId, string? name, string? phone)
    {
        var editedRow = await _restaurantService.EditRestaurant(restaurantId, name, phone);

        return editedRow == 1 ? Ok("Registro atualizado com sucesso!") : BadRequest("Não foi encontrado nenhum registro com esse id");
    }
    
    [HttpDelete]
    [Route("Restaurant")]
    public async Task<IActionResult> DeleteRestaurant([FromQuery] int restaurantId)
    {
        await _restaurantService.DeleteRestaurant(restaurantId);

        return Ok("Registro excluído com sucesso!");
    }
}