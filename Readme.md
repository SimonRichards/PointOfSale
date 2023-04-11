### Point Of Sale Terminal
This class library implements product scanning and price totally functionality for a point of sale terminal.
Logic to collate all sales and calculate a final price is in the Terminal class. Information on pricing is
provided through the IPricing interface. This is implemented as an in-memory store for the purpose of this demo.

Practically the IPricing implementation could include caching, db or api access and would need to be changed to
async. Setting the price is provided for testing purposes since in practice this would neither be baked into
the library nor set at the point of sale.

Tests in the PointOfSaleTest library demonstrate the minimum functionality required as well as an exceptional
case and the ability to reset for the next customer.
