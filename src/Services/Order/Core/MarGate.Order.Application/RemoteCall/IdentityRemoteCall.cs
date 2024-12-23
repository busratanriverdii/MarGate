using MarGate.Order.Application.RemoteCall.Responses;
using Newtonsoft.Json;

namespace MarGate.Order.Application.RemoteCall;

public interface IIdentityRemoteCall
{
    Task<GetUserByIdResponse> GetUserById(long userId);
}

public class IdentityRemoteCall : IIdentityRemoteCall
{
    private readonly HttpClient _httpClient;

    public IdentityRemoteCall(IHttpClientFactory httpClientFactory)
    {
        this._httpClient = httpClientFactory.CreateClient("identity");
    }

    public async Task<GetUserByIdResponse> GetUserById(long userId)
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/users/{userId}");
        var httpMessageResponse = await _httpClient.SendAsync(requestMessage);

        var response = await httpMessageResponse.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<GetUserByIdResponse>(response);
    }
}
