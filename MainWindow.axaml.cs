using Avalonia.Controls;
using Avalonia.Interactivity;

namespace projekt2
{
    public partial class MainWindow : Window
    {
        private decimal currentBalance;
        private ComputerWindow computerWindow;

        public MainWindow()
        {
            InitializeComponent();
            computerWindow = new ComputerWindow();
            currentBalance = 1000;
            UpdateTotalPriceTextBox();
        }

        private void OpenComputerWindow(object sender, RoutedEventArgs e)
        {
            computerWindow.Show();
        }

        private void OpenMonitorWindow(object sender, RoutedEventArgs e)
        {
            var monitorWindow = new MonitorWindow();
            monitorWindow.MonitorSelected += (s, price) =>
            {
                computerWindow.UpdateBudget();
            };
            monitorWindow.Show();
        }
        private void UpdateTotalPriceTextBox()
        {
            TotalPriceTextBox.Text = currentBalance.ToString("N2");
        }
    }
}