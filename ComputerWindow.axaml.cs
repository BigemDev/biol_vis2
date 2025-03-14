using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using Avalonia.Media;
using System.Linq; 

namespace projekt2
{
    public partial class ComputerWindow : Window
    {
        private MainWindow _mainWindow;
        public ComputerWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void UpdateBudgetTextBlock()
        {
            // Reszta : 1000 zł"
            BudgetTextBlock.Text ="Reszta : " + (1000 - (App._PricesArray[0] + App._PricesArray[1])).ToString() + " zł";
        }

        private void ComboBoxSelection(object sender, SelectionChangedEventArgs e)
        {
            if (ProcessorComboBox.SelectedItem is ComboBoxItem item)    
            {
                if (item.Content is StackPanel stackPanel)
                {
                    if (stackPanel.Children[1] is TextBlock priceBlock)
                    {
                        App._PricesArray[0] = Convert.ToDecimal(priceBlock.Tag);
                        // priceBlock.Background = Brushes.Red;
                        UpdateBudgetTextBlock();
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

        private void OnDiskChecked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton && radioButton.IsChecked == true)
            {
                App._PricesArray[1] = Convert.ToDecimal(radioButton.Tag);
                DiskTextBox.Text = App._PricesArray[1].ToString() + " zł";
                UpdateBudgetTextBlock();
            }
        }
    }
}