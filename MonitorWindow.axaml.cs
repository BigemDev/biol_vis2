using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace projekt2
{
    public partial class MonitorWindow : Window
    {
        public event EventHandler<int> MonitorSelected;

        public MonitorWindow()
        {
            InitializeComponent();
        }

        private void OnOKClick(object sender, RoutedEventArgs e)
        {
            if (MonitorListView.SelectedItem is ListBoxItem selectedItem)
            {
                if (selectedItem.Content is StackPanel stackPanel)
                {
                    var priceTextBlock = stackPanel.Children[1] as TextBlock;
                    if (priceTextBlock != null && int.TryParse(priceTextBlock.Text.Replace(" zł", ""), out int price))
                    {
                        MonitorSelected?.Invoke(this, price);
                    }
                }
            }
            Close();
        }

        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}