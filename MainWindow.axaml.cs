using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Linq; 

namespace projekt2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TotalPriceTextBox.Text = App._totalPrice.ToString();
        }

        public void OpenComputerWindow(object sender, RoutedEventArgs e)    
        {
            var computerWindow = new ComputerWindow(this);
            computerWindow.Show();
        }
        public void OpenMonitorWindow(object sender, RoutedEventArgs e)
        {
            var monitorWindow = new MonitorWindow(this);
            monitorWindow.Show();
        }
        public void UpdateTotalPrice(object sender, RoutedEventArgs e)
        {
            TotalPriceTextBox.Text = (App._PricesArray[0] + App._PricesArray[1] + App._PricesArray[2]).ToString();   
        }
        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}