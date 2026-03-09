using System;

namespace RapidPack.Services;

public class ParcelCalculator
{
    public decimal CalculatePrice(decimal height, decimal width, decimal depth, decimal weight,
        bool express, string packageType)
    {
        decimal TotalPrice = 0;
        
        if (weight > 30)
            throw new Exception("Nie wozimy paczek cięższych niż 30 kg!");
        
        if (packageType.Contains("Paleta"))
        {
            TotalPrice = 100m;
        }
        else
        {
            TotalPrice = 10m + (weight * 2m);

            decimal fullSize = height + width + depth;

            if (fullSize > 150)
                TotalPrice *= 1.5m;

            if (packageType.Contains("Ostrożnie"))
                TotalPrice += 10m;
        }
        
        if (express)
            TotalPrice += 15m;
        
        return TotalPrice;
    }
}