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
                if (!decimal.TryParse(PackHeight.Text, out decimal height) ||
                    !decimal.TryParse(PackWidth.Text, out decimal width) ||
                    !decimal.TryParse(PackDepth.Text, out decimal depth) ||
                    !decimal.TryParse(PackWeight.Text, out decimal weight))
                {
                    TotalPrice.Text = "Błąd: wpisz liczby!";
                    return;
                }
                
                bool express = Express.IsChecked ?? false;

                string shipmentType = "";

                if (ComboBox.SelectedItem is ComboBoxItem item)
                    shipmentType = item.Content?.ToString();

                decimal price = calculator.CalculatePrice(height, width, depth, weight, express, shipmentType);

                TotalPrice.Text = $"Cena: {price} zł";
            }
            catch (Exception blad)
            {
                TotalPrice.Text = blad.Message;
            }

        }
    }
}