using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using App.Services;

namespace App.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {

        private bool _isPaneOpen = false;
        private UserControl _currentPage;
        private PageViewModel _selectedPage;
        public bool IsPaneOpen
        {
            get => _isPaneOpen;
            set => this.SetProperty(ref _isPaneOpen, value);
        }
        public void TriggerPaneCommand()
        {
            IsPaneOpen = !IsPaneOpen;
        }
        
        public PageViewModel SelectedPage
        {
            get => _selectedPage;
            set
            {
                this.SetProperty(ref _selectedPage, value);
                if (value != null)
                {
                    CurrentPage = value.Page;
                }
            }
        }
        public ObservableCollection<PageViewModel> Pages { get; }

        public UserControl CurrentPage
        {
            get => _currentPage;
            set => this.SetProperty(ref _currentPage, value);
        }
        public ICommand ChangePageCommand { get; }
        public MainWindowViewModel()
        {
            // Устанавливаем начальный экран
            CurrentPage = new DataPageView();

            // Инициализируем коллекцию страниц
            Pages = new ObservableCollection<PageViewModel>
             {
            new PageViewModel { Title = "Данные", Page = new DataPageView(),  IconData = "BookDatabaseRegular" },
            new PageViewModel { Title = "Настройка", Page = new SettingPageView() }
                };
            // Инициализируем команду
            ChangePageCommand = new RelayCommand<PageViewModel>(ChangePage);
        }
        private void ChangePage(PageViewModel page)
        {
            CurrentPage = page.Page;
        }
        public class PageViewModel
        {
            public string Title { get; set; }
            public UserControl Page { get; set; }
            public string IconData { get; set; }
        }



    }    
}
