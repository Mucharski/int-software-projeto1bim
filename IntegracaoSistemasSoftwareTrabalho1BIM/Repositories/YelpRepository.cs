using Flurl;
using Flurl.Http;
using IntegracaoSistemasSoftwareTrabalho1BIM.Entities.Yelp;
using IntegracaoSistemasSoftwareTrabalho1BIM.Repositories.Interfaces;
using Newtonsoft.Json;

namespace IntegracaoSistemasSoftwareTrabalho1BIM.Repositories;

public class YelpRepository : IYelpRepository
{
    private readonly string _apiKey = Environment.GetEnvironmentVariable("YELP_APIKEY") ??
                                      throw new NullReferenceException("Chave da API não encontrada");

    private readonly string _clientId = Environment.GetEnvironmentVariable("YELP_CLIENTID") ??
                                        throw new NullReferenceException("ID do cliente não encontrado");

    private readonly string _baseUrl = "https://api.yelp.com/v3/";

    public async Task<BusinessesJsonReturn> ListRestaurants(string location)
    {
        IFlurlRequest url = _baseUrl.AppendPathSegment("businesses").AppendPathSegment("search")
            .SetQueryParams(new
            {
                sort_by = "best_match",
                limit = "5",
                location
            })
            .WithOAuthBearerToken(_apiKey);

        IFlurlResponse flurlResponse = await url.GetAsync();

        if (flurlResponse.StatusCode is >= 400 and <= 499)
        {
            throw new HttpRequestException(flurlResponse.ToString());
        }

        BusinessesJsonReturn response = await flurlResponse.GetJsonAsync<BusinessesJsonReturn>();

        return response;
    }
}