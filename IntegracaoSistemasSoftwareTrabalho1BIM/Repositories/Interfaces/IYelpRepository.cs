using IntegracaoSistemasSoftwareTrabalho1BIM.Entities.Yelp;

namespace IntegracaoSistemasSoftwareTrabalho1BIM.Repositories.Interfaces;

public interface IYelpRepository
{
    public Task<BusinessesJsonReturn> ListRestaurants(string location);
}