using System.Windows;

namespace ClientWpf
{
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }
        
        private void Auth_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}