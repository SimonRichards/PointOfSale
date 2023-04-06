namespace PointOfSaleTerminal;

public interface IPricing {
    decimal GetUnitPrice(string product);
    VolumePrice? GetVolumePrice(string product);
}