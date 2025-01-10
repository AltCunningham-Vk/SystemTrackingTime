using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using App.ViewModels;

namespace App;

public partial class HomePageView : UserControl
{
    public HomePageView()
    {
        InitializeComponent();
        DataContext = new HomePageViewModel();
    }
}