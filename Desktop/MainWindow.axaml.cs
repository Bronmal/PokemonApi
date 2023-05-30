using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Desktop;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void AuthButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Dictionary<string, string> json = new Dictionary<string, string>()
        {
            { "login", LoginBox.Text},
            { "password", PasswordBox.Text}
        };
        var response = await ClientToApi.Api.Client.PostAsJsonAsync("Authorization/auth", json);
        ClientToApi.Jwt = await response.Content.ReadAsStringAsync();

        if (response.StatusCode == HttpStatusCode.OK && ClientToApi.Jwt != "")
        {
            PokemonsWindow pokemonsWindow = new PokemonsWindow();
            pokemonsWindow.Show();
            Close();
        }
    }
}