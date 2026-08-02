using System;

public class Order
{
    private List<Product> _products;
private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double totalCost = 0;
        foreach (var product in _products)
        {
            totalCost += product.GetTotalCost();
        }
        if (_customer.LivesInUSA())
        {
            totalCost += 5; // Add $5 shipping cost for USA orders
        }
        else
        {
            totalCost += 35; // Add $35 shipping cost for international orders
        }
        
        return totalCost;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        foreach (var product in _products)
        {
            packingLabel += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        string shippingLabel = "Shipping Label:\n";
        shippingLabel += $"Customer Name: {_customer.GetName()}\n";
        shippingLabel += $"Address: {_customer.GetAddress().GetFullAddress()}\n";
        return shippingLabel;
    }
}

