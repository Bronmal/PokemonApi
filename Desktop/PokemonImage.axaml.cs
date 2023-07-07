using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using SkiaSharp;

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
        MemoryStream stream = new MemoryStream(imageBytes);
        Bitmap bitmap = new Bitmap(stream);

        DataContext = bitmap;
    }
}