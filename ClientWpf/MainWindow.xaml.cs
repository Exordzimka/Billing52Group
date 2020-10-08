using System.Windows;

namespace ClientWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Closing += ClosingApp;
        }
        
        private void ClosingApp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Application.Current.Shutdown();
        }
        
        
    }
    
    public class Phone
    {
        public string Title { get; set; }
        public string Company { get; set; }
        public int Price { get; set; }
    }
}