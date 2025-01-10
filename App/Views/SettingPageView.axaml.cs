using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using App.ViewModels;

namespace App;

public partial class SettingPageView : UserControl
{
    public SettingPageView()
    {
        InitializeComponent();
        DataContext = new SettingPageViewModel();
    }
}