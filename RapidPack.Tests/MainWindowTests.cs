using RapidPack.Services;
using Xunit;
using System;

namespace RapidPack.Tests
{
    public class ParcelCalculatorTests
    {
        private readonly ParcelCalculator calculator = new ParcelCalculator();

        [Fact]
        public void WeightAbove30Error()
        {
            var error = Assert.Throws<Exception>(() =>
                calculator.CalculatePrice(10, 10, 10, 35, false, "Standardowa"));

            Assert.Equal("Nie wozimy paczek cięższych niż 30 kg!", error.Message);
        }

        [Fact]
        public void LargePackage50Percent()
        {
            // Paczka o sumie wymiarów >150 cm → +50%
            decimal TotalPrice = calculator.CalculatePrice(50, 50, 60, 10, false, "Standardowa");

            // 10 + 10*2 = 30 | 30 + 50% = 45
            Assert.Equal(45m, TotalPrice);
        }

        [Fact]
        public void PaletaAlways100()
        {
            // Paleta cena = zawsze 100 zł
            decimal price = calculator.CalculatePrice(200, 200, 200, 25, false, "Paleta");

            Assert.Equal(100m, price);
        }

        [Fact]
        public void ExpressAndFragileExtraFees()
        {
            // Paczka Ostroznie + Express = + 10 + 15 = +25
            decimal price = calculator.CalculatePrice(10, 10, 10, 5, true, "Ostrożnie (+10zł)");

            // 10 + 5*2 = 20 | 20 +10 (Ostrożnie) +15 (Express) = 45
            Assert.Equal(45m, price);
        }
    }
}