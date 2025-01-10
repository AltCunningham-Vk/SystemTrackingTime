using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using App.ViewModels;

namespace App;

public partial class DataPageView : UserControl
{
    public DataPageView()
    {
        InitializeComponent();
        DataContext = new DataPageViewModel();
    }
}