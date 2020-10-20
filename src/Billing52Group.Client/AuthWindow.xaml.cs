using System.Windows;

namespace Billing52Group.Client
{
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Auth_Click(object sender, RoutedEventArgs e)
        {
            // var result = new BillingApiV1HttpService();
            //
            // try
            // {
            //     var contracts = await result.GetContracts();
            // }
            // catch (Exception except)
            // {
            //     MessageBox.Show(except.Message);
            // }

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}