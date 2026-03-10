using RapidPack.Services;
using Xunit;
using System;

namespace RapidPack.Tests
{
    public class ParcelCalculatorTests
    {
        private readonly ParcelCalculator calculator = new ParcelCalculator();

        [Fact]
        public void WeightAbove30_ShouldShowError()
        {
            var error = Assert.Throws<Exception>(() =>
                calculator.CalculatePrice(10, 10, 10, 31, false, "Standardowa"));

            Assert.Equal("Nie wozimy paczek cięższych niż 30 kg!", error.Message);
        }

        [Fact]
        public void LargePackageOver150_ShouldAdd50Percent()
        {
            // Paczka o sumie wymiarów >150 cm → +50%
            double TotalPrice = calculator.CalculatePrice(57, 50, 63, 10, false, "Standardowa");

            // 10 + 10*2 = 30 | 30 + 50% = 45
            Assert.Equal(45, TotalPrice);
        }

        [Fact]
        public void PaletaShouldAlwaysCost100()
        {
            // Paleta cena = zawsze 100 zł
            double price = calculator.CalculatePrice(64, 223, 156, 25, false, "Paleta");

            Assert.Equal(100, price);
        }

        [Fact] public void ExpressAndFragile_ShouldAddExtraFees()
        {
            // Paczka Ostroznie + Express = + 10 + 15 = +25
            double price = calculator.CalculatePrice(13, 7, 21, 5, true, "Ostrożnie (+10zł)");

            // 10 + 5*2 = 20 | 20 +10 (Ostrożnie) +15 (Express) = 45
            Assert.Equal(45, price);
        }
    }
}