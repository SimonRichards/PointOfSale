
namespace PointOfSaleTerminal;

public class Terminal {
    private readonly IPricing _pricing;

    private readonly Dictionary<string, int> _productsScanned = new();

    public Terminal(IPricing pricing) {
        _pricing = pricing;
    }

    public void ScanProduct(string product) {
        _productsScanned.TryGetValue(product, out int count);
        _productsScanned[product] = count + 1;
    }

    public decimal CalculateTotal() {
        return _productsScanned.Select(pair => GetPriceAtQuantity(pair.Key, pair.Value)).Sum();
    }

    public void Reset() {
        _productsScanned.Clear();
    }

    public decimal GetPriceAtQuantity(string product, int quantity) {
        VolumePrice? volume = _pricing.GetVolumePrice(product);
        decimal unitPrice = _pricing.GetUnitPrice(product);
        return volume == null
            ? unitPrice * quantity
            : volume.Price * (quantity / volume.Quantity) + unitPrice * (quantity % volume.Quantity);
    }
}
