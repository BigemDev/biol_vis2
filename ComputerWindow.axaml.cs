using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace projekt2
{
    public partial class ComputerWindow : Window
    {
        private const int TotalBudget = 1000;
        private int processorPrice = 0;
        private int diskPrice = 0;

        public event EventHandler<int> TotalPriceUpdated;

        public ComputerWindow()
        {
            InitializeComponent();
        }

        private void OnProcessorSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProcessorComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                var stackPanel = selectedItem.Content as StackPanel;
                var priceTextBlock = stackPanel?.Children[1] as TextBlock;
                if (priceTextBlock != null)
                {
                    string priceText = priceTextBlock.Text.Replace(" zł", "");
                    if (int.TryParse(priceText, out int price))
                    {
                        processorPrice = price;
                        UpdateBudget();
                    }
                }
            }
        }

        private void OnDiskChecked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton)
            {
                if (int.TryParse(radioButton.Tag?.ToString(), out int price))
                {
                    diskPrice = price;
                    DiskTextBox.Text = price.ToString();
                    UpdateBudget();
                }
            }
        }

        public void UpdateBudget()
        {
            int remainingBudget = TotalBudget - processorPrice - diskPrice;
            BudgetTextBlock.Text = $"Reszta : {remainingBudget} zł";

            int totalPrice = processorPrice + diskPrice;
            TotalPriceUpdated?.Invoke(this, totalPrice);
        }

        private void OnOKClick(object sender, RoutedEventArgs e)
        {
            // Implement OK button logic here
            Close();
        }

        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}