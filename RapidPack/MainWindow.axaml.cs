using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using RapidPack.Services;

namespace RapidPack
{
    public partial class MainWindow : Window
    {
        public ParcelCalculator calculator = new ParcelCalculator();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void calculation(object? sender, RoutedEventArgs e)
        {
            try
            {
                if (!double.TryParse(PackHeight.Text, out double height) ||
                    !double.TryParse(PackWidth.Text, out double width) ||
                    !double.TryParse(PackDepth.Text, out double depth) ||
                    !double.TryParse(PackWeight.Text, out double weight))
                {
                    TotalPrice.Text = "Błąd: wpisz liczby!";
                    return;
                }
                
                bool express = Express.IsChecked ?? false;

                string shipmentType = "";

                if (ComboBox.SelectedItem is ComboBoxItem item)
                    shipmentType = item.Content?.ToString();

                double totalPrice = calculator.CalculatePrice(height, width, depth, weight, express, shipmentType);

                TotalPrice.Text = $"Cena: {totalPrice} zł";
            }
            catch (Exception error)
            {
                TotalPrice.Text = error.Message;
            }
        }
    }
}