using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Desktop;

public partial class PokemonImage : Window
{
    public PokemonImage()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}