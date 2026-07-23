using System;

class Program
{
    static void Main(string[] args)
    {
        // ---- Order 1: USA customer ----
        Address address1 = new Address("123 Maple Street", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("Jamie Turner", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Wireless Mouse", "A101", 15.99, 2));
        order1.AddProduct(new Product("Mechanical Keyboard", "A202", 49.99, 1));
        order1.AddProduct(new Product("USB-C Hub", "A303", 22.50, 3));

        // ---- Order 2: Non-USA customer ----
        Address address2 = new Address("48 Baker Lane", "Manchester", "England", "United Kingdom");
        Customer customer2 = new Customer("Priya Anand", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Desk Lamp", "B104", 27.75, 1));
        order2.AddProduct(new Product("Ceramic Mug Set", "B215", 18.00, 2));

        // ---- Display Order 1 ----
        Console.WriteLine("Order 1");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Price: ${order1.GetTotalCost():0.00}");
        Console.WriteLine();
        Console.WriteLine(new string('-', 40));
        Console.WriteLine();

        // ---- Display Order 2 ----
        Console.WriteLine("Order 2");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Price: ${order2.GetTotalCost():0.00}");
    }
}