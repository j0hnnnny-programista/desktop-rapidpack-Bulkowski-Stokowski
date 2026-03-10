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
                if (!int.TryParse(PackHeight.Text, out int height) ||
                    !int.TryParse(PackWidth.Text, out int width) ||
                    !int.TryParse(PackDepth.Text, out int depth) ||
                    !int.TryParse(PackWeight.Text, out int weight))
                {
                    TotalPrice.Text = "Błąd: wpisz liczby!";
                    return;
                }
        }
    }
}