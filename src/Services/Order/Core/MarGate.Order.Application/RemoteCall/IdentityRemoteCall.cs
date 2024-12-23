using MarGate.Core.Api.Responses.Results;
using MarGate.Order.Application.RemoteCall.Responses;
using Newtonsoft.Json;

namespace MarGate.Order.Application.RemoteCall;

public interface IIdentityRemoteCall
{
    Task<Result<GetUserByIdResponse>> GetUserById(long userId);
}

public class IdentityRemoteCall(IHttpClientFactory httpClientFactory) : IIdentityRemoteCall
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("Identity");

    public async Task<Result<GetUserByIdResponse>> GetUserById(long userId)
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/users/{userId}");
        var httpMessageResponse = await _httpClient.SendAsync(requestMessage);

        var response = await httpMessageResponse.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<Result<GetUserByIdResponse>>(response);
    }
}
