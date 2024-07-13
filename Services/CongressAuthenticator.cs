using System;

public class CongressAuthenticator
{
  private string _apiKey;

  public CongressAuthenticator(string apiKey)
  {
    _apiKey = apiKey;
  }

  public void AddAuthenticationHeader(HttpRequestMessage request)
  {
    request.Headers.Add("X-API-Key", _apiKey);
  }
}
