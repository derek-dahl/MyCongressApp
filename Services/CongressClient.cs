public class CongressClient
{
    private readonly HttpClient _httpClient;
    private readonly CongressAuthenticator _authenticator;

    public CongressClient(HttpClient httpClient, CongressAuthenticator authenticator)
    {
        _httpClient = httpClient;
        _authenticator = authenticator;
    }

    public async Task<string> GetBillDetails(string billNumber)
    {
        // Construct and send HTTP request
        var request = new HttpRequestMessage(
            HttpMethod.Get,
            $"https://api.congress.gov/v3/bill/{billNumber}?format=json"
        );
        _authenticator.AddAuthenticationHeader(request);
        var response = await _httpClient.SendAsync(request);

        // Check response status
        if (response.IsSuccessStatusCode)
        {
            // Read response content
            return await response.Content.ReadAsStringAsync();
        }
        else
        {
            // Handle error response
            return null;
        }
    }
}
