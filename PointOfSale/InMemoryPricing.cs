namespace PointOfSaleTerminal;

public class InMemoryPricing : IPricing {

    private readonly Dictionary<string, decimal> _unitPrice = new();
    private readonly Dictionary<string, VolumePrice> _volumePrice = new();

    public void SetUnitPrice(string product, decimal price) {
        _unitPrice[product] = price;
    }

    public void SetVolumePrice(string product, VolumePrice price) {
        _volumePrice[product] = price;
    }

    public decimal GetUnitPrice(string product) {
        if (!_unitPrice.TryGetValue(product, out var unitPrice)) {
            throw new InvalidOperationException($"Price not available for {product}");
        }
        return unitPrice;
    }

    public VolumePrice? GetVolumePrice(string product) {
        return _volumePrice.TryGetValue(product, out var volumePrice) ? volumePrice : null;
    }
}
