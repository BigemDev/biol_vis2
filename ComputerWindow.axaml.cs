using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace projekt2
{
    public partial class ComputerWindow : Window
    {
        private int budget = 1000;
        private TextBlock budgetTextBlock;

        public ComputerWindow()
        {
            InitializeComponent();
            budgetTextBlock = this.FindControl<TextBlock>("BudgetTextBlock");
            UpdateBudgetDisplay();
        }

        public void UpdateBudget(int amount)
        {
            budget -= amount;
            UpdateBudgetDisplay();
        }

        private void UpdateBudgetDisplay()
        {
            if (budgetTextBlock != null)
            {
                budgetTextBlock.Text = $"Reszta : {budget} zł";
            }
        }

        private void OnOKClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}