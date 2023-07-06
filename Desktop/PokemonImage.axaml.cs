using System.Collections.Generic;
using System.IO;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Desktop;

public partial class PokemonImage : Window
{
    public PokemonImage()
    {
        InitializeComponent();
    }
    
    public PokemonImage(byte[] imageBytes)
    {
        InitializeComponent();
        var array = imageBytes.ToArray();
        Stream stream = new MemoryStream(array);
        var image = new Avalonia.Media.Imaging.Bitmap(stream);

        pokemonImage.Source = image;
    }
}