using System;
using System.Net.Http;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Desktop;

namespace Desktop;

public class ClientToApi
{
    private HttpClientHandler hand = new HttpClientHandler();
    public readonly HttpClient Client;
    public static ClientToApi Api;
    public static string Jwt;

    public ClientToApi()
    {
        hand.ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true;
        Client = new HttpClient(hand);
        Client.BaseAddress = new Uri("http://localhost:5164/api/");
    }

    [ModuleInitializer]
    internal static void Initialize()
    {
        Api = new ClientToApi();
    }
}
