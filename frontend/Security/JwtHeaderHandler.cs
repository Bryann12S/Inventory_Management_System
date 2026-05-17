using Blazored.LocalStorage; 
using System.Net.Http.Headers;

namespace frontend.Security;

public class JwtHeaderHandler : DelegatingHandler
{
    private readonly ILocalStorageService _LocalStorage;

    public JwtHeaderHandler(ILocalStorageService localStorage)
    {
        _LocalStorage = localStorage;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        //Token in LocalStorage
        var token = await _LocalStorage.GetItemAsync<string>("authtoken", cancellationToken);

        if(!string.IsNullOrWhiteSpace(token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        }

        //next
        return await base.SendAsync(request, cancellationToken);
    }
}