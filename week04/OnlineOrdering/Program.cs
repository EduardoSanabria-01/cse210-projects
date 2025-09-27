// Program.cs
class Program
{
    static void Main(string[] args)
    {
        // --- Order 1 (USA Customer) ---
        Address address1 = new Address("123 Maple St", "Anytown", "CA", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);
        
        order1.AddProduct(new Product("Laptop", "PROD-001", 1200.50m, 1));
        order1.AddProduct(new Product("Mouse", "PROD-002", 25.00m, 2));

        Console.WriteLine("--- Order 1 Details ---");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalCost():F2}\n");
        Console.WriteLine("========================================\n");


        // --- Order 2 (International Customer) ---
        Address address2 = new Address("456 Oak Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Keyboard", "PROD-003", 75.99m, 1));
        order2.AddProduct(new Product("Monitor", "PROD-004", 300.00m, 2));
        order2.AddProduct(new Product("Webcam", "PROD-005", 49.95m, 1));

        Console.WriteLine("--- Order 2 Details ---");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalCost():F2}\n");
    }
}