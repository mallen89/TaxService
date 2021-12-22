namespace TaxCalculatorInterface
{
    public interface ITaxCalculator
    {
        double GetTaxRateByLocation(int ZipCode);
        double CacluclateTaxForOrder(float OrderAmount, float ShippingAmount, Address FromAddress, Address ToAddress);
    }
}
