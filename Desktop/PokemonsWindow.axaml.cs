using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Templates;
using Pokemons.Respositories.Common;
using MessageBox.Avalonia;
using MessageBox.Avalonia.DTO;
using MessageBox.Avalonia.Enums;

namespace Desktop;

public partial class PokemonsWindow : Window
{
    private HttpMethod postMethod;

    public PokemonsWindow()
    {
        InitializeComponent();
        ClientToApi.Api.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ClientToApi.Jwt);
        List<PokemonJsonStruct>? pokemons = GetPokemons();
        PokemonsGrid.Items = pokemons;
    }

    private List<PokemonJsonStruct>? GetPokemons()
    {
        var responseTask = ClientToApi.Api.Client.GetAsync("Pokemons/get_pokemons");
        responseTask.Wait();
        var jsonTask = responseTask.Result.Content.ReadAsStringAsync();
        jsonTask.Wait();
        return JsonSerializer.Deserialize <List<PokemonJsonStruct>>(jsonTask.Result);
    }

    private async void OnTappedTypes(object? sender, RoutedEventArgs e)
    {
        var response = await ClientToApi.Api.Client.GetAsync("Pokemons/get_types_of_pokemon");
        var json = await response.Content.ReadAsStringAsync();
        var pokemonsTypes = JsonSerializer.Deserialize <List<PokemonTypeJsonStruct>>(json);
        PokemonsTypeGrid.Items = pokemonsTypes;
    }

    private async void OnTappedParametrs(object? sender, RoutedEventArgs e)
    {
        var response = await ClientToApi.Api.Client.GetAsync("Pokemons/get_stats");
        var json = await response.Content.ReadAsStringAsync();
        var pokemonsParametrs = JsonSerializer.Deserialize <List<StatJsonStruct>>(json);
        PokemonsParametrsGrid.Items = pokemonsParametrs;
    }
    
    private async void OnTappedAbilities(object? sender, RoutedEventArgs e)
    {
        // var response = await ClientToApi.Api.Client.GetAsync("Pokemons/get_abilities");
        // var json = await response.Content.ReadAsStringAsync();
        // var pokemonsParametrs = JsonSerializer.Deserialize <List<string>>(json);
        // PokemonsAbilityGrid.Items = pokemonsParametrs;
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        var rowData = (dynamic)button.DataContext;
        
        var response = await ClientToApi.Api.Client.GetAsync("Pokemons/like_pockemon/" + (string)rowData.Id);
        var json = await response.Content.ReadAsStringAsync();
    }

    private async void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        Dictionary<string, string> jsonToSend = new Dictionary<string, string>();
        jsonToSend["time"] = "day";
        var response = await ClientToApi.Api.Client.PostAsJsonAsync("Pokemons/get_most_liked_pockemon", jsonToSend);
        var json = await response.Content.ReadAsStringAsync();
        if (json == "Ни один покемон еще не лайкнут") {var box = MessageBoxManager.GetMessageBoxStandardWindow("Информация", json);
            await box.Show();
            return;}
        var pokemons= JsonSerializer.Deserialize <PokemonJsonStruct>(json);
        var box1 = MessageBoxManager.GetMessageBoxStandardWindow("Информация", pokemons.Name);
        await box1.Show();
    }

    private async void Button_OnClick1(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        var rowData = (dynamic)button.DataContext;
        
        Dictionary<string, string> a = new Dictionary<string, string>();
        a["name"] = (string)rowData.Name;
        var response = await ClientToApi.Api.Client.PostAsJsonAsync("Pokemons/get_image", a);
        var json = await response.Content.ReadAsStringAsync();

        byte[] imageBytes =  JsonSerializer.Deserialize<byte[]>(json);
        PokemonImage b = new PokemonImage(imageBytes);
        b.Show();
    }
}