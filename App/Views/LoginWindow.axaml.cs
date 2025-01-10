using Avalonia.Controls;
using Avalonia.Interactivity;
using App.Services;

namespace App.Views
{
    public partial class LoginWindow : Window
    {
        private readonly AuthService _authService;

        public LoginWindow()
        {
            InitializeComponent();
            _authService = new AuthService();
        }

        private void OnLoginButtonClick(object sender, RoutedEventArgs e)
        {
            // Пример простой проверки аутентификации
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            if (_authService.Authenticate(username, password)) // Замените на реальную проверку
            {
                // Аутентификация успешна
                var mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                // Показать сообщение об ошибке
            var errorWindow = new Window
            {
                Title = "Error",
                Width = 300,
                Height = 150,
                Content = new TextBlock { Text = "Invalid username or password", HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center, VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center }
            };
            errorWindow.ShowDialog(this);
            }
        }
    }
}