using System;

namespace RapidPack.Services;

public class ParcelCalculator
{
    public double CalculatePrice(double height, double width, double depth, double weight,
        bool express, string packageType)
    {
        double TotalPrice = 0.0;
        
        if (weight > 30)
            throw new Exception("Nie wozimy paczek cięższych niż 30 kg!");
        
        if (packageType.Contains("Paleta"))
        {
            TotalPrice = 100;
        }
        else
        {
            TotalPrice = 10 + (weight * 2);

            double fullSize = height + width + depth;

            if (fullSize > 150)
                TotalPrice *= 1.5;

            if (packageType.Contains("Ostrożnie"))
                TotalPrice += 10;
        }
        
        if (express)
            TotalPrice += 15;
        
        return TotalPrice;
    }
}