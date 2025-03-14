using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Linq; 
using Avalonia;

namespace projekt2
{
    public partial class MonitorWindow : Window
    {
        private MainWindow _mainWindow;
        public MonitorWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void MonitorSelection(object sender, SelectionChangedEventArgs e)
        {
            if (MonitorListView.SelectedItem is ListBoxItem selectedItem)
            {
                if (selectedItem.Content is StackPanel stackPanel)
                {
                    if (stackPanel.Children[1] is TextBlock priceBlock)
                    {
                        MonitorPrice.Text = priceBlock.Tag.ToString() + " zł";
                        App._PricesArray[2] = Convert.ToDecimal(priceBlock.Tag);
                        // priceBlock.Background = Brushes.Red;
                    }
                }
            }
        }

        private void OnOkClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.UpdateTotalPrice(null,null);
            Close();
        }
        
        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}