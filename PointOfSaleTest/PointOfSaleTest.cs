using System;
using NUnit.Framework;
using PointOfSaleTerminal;
namespace PointOfSaleTest;

public class Tests {
    private InMemoryPricing _pricing;
    [SetUp]
    public void Setup() {
        _pricing = new InMemoryPricing();
        _pricing.SetUnitPrice("A", 1.25m);
        _pricing.SetVolumePrice("A", new VolumePrice { Quantity = 3, Price = 3 });
        _pricing.SetUnitPrice("B", 4.25m);
        _pricing.SetUnitPrice("C", 1m);
        _pricing.SetVolumePrice("C", new VolumePrice { Quantity = 6, Price = 5 });
        _pricing.SetUnitPrice("D", 0.75m);
    }

    [Test]
    public void Test1() {
        var terminal = new Terminal(_pricing);
        ScanTestString(terminal, "ABCDABA");
        Assert.That(terminal.CalculateTotal(), Is.EqualTo(13.25m));
    }

    [Test]
    public void Test2() {
        var terminal = new Terminal(_pricing);
        ScanTestString(terminal, "CCCCCCC");
        Assert.That(terminal.CalculateTotal(), Is.EqualTo(6.00m));
    }

    [Test]
    public void Test3() {
        var terminal = new Terminal(_pricing);
        ScanTestString(terminal, "ABCD");
        Assert.That(terminal.CalculateTotal(), Is.EqualTo(7.25m));
    }

    [Test]
    public void TestMissingProduct() {
        var terminal = new Terminal(_pricing);
        terminal.ScanProduct("Missing Product");
        Assert.Throws<InvalidOperationException>(() => terminal.CalculateTotal());

    }

    private void ScanTestString(Terminal terminal, string products) {
        foreach (char c in products) {
            terminal.ScanProduct(c.ToString());
        }   
    }
}