using System;
namespace RapidPack.Services;

public class ParcelCalculator
{
    public double CalculatePrice(double height, double width, double depth, double weight,
        bool express, string packageType)
    {
        double totalPrice = 0.0;
        
        if (weight > 30)
            throw new Exception("Nie wozimy paczek cięższych niż 30 kg!");
        
        if (packageType.Contains("Paleta"))
        {
            totalPrice = 100;
        }
        else
        {
            
            totalPrice = 10 + (weight * 2);

            double fullSize = height + width + depth;

            if (fullSize > 150)
                totalPrice *= 1.5;

            if (packageType.Contains("Ostrożnie"))
                totalPrice += 10;
        }
        
        if (express)
            totalPrice += 15;
        
        return totalPrice;
    }
}