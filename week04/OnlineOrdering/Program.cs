using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA", "12345");
        Customer customer1 = new Customer("John Doe", address1);

        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Widget", "W123", 19.99, 2));
        order1.AddProduct(new Product("Gadget", "G456", 29.99, 1));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():0.00}");


        Address address2 = new Address("456 Elm St", "Othercity", "ON", "Canada", "A1B 2C3");
        Customer customer2 = new Customer("Jane Smith", address2);
        
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Tool", "T789", 39.99, 1));
        order2.AddProduct(new Product("Device", "D012", 49.99, 2));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():0.00}");
    }
    
}