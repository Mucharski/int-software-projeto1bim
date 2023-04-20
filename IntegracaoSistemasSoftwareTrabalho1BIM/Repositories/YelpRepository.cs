using Flurl;
using Flurl.Http;
using IntegracaoSistemasSoftwareTrabalho1BIM.Repositories.Interfaces;

namespace IntegracaoSistemasSoftwareTrabalho1BIM.Repositories;

public class YelpRepository : IYelpRepository
{
    private readonly string _apiKey = Environment.GetEnvironmentVariable("YELP_APIKEY") ?? 
                                      throw new NullReferenceException("Chave da API não encontrada");
    private readonly string _clientId = Environment.GetEnvironmentVariable("YELP_CLIENTID") ?? 
                                        throw new NullReferenceException("ID do cliente não encontrado");

    private readonly string _baseUrl = "https://api.yelp.com/v3/";
    
    public async Task<string> ListRestaurants()
    {
        IFlurlRequest url = _baseUrl.AppendPathSegment("businesses").AppendPathSegment("search")
            .SetQueryParams(new
            {
                sort_by = "best_match",
                limit = "5",
                location = "Curitiba"
            })
            .WithOAuthBearerToken(_apiKey);
        
        return "Teste";
    }
}