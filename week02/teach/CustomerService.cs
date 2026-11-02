/// <summary>
/// Maintain a Customer Service Queue. Allows new customers to be
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Test Cases

        // Test 1
        // Scenario: Create a queue with a maximum size of 2.
        // Add two customers and attempt to add a third customer.
        // Expected Result: The first two customers should be added.
        // The third customer should not be added, and an error
        // message should be displayed.
        Console.WriteLine("Test 1");
        var cs = new CustomerService(2);

        cs.AddNewCustomer();
        cs.AddNewCustomer();

        Console.WriteLine(cs);

        cs.AddNewCustomer();

        Console.WriteLine(cs);

        // Defect(s) Found:
        // The full queue check used > instead of >=, which allowed
        // an additional customer to be added when the queue was full.

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Add two customers and serve them.
        // Expected Result: Customers should be served in the same
        // order they were added (FIFO).
        Console.WriteLine("Test 2");
        cs = new CustomerService(2);

        cs.AddNewCustomer();
        cs.AddNewCustomer();

        Console.WriteLine("Serving first customer:");
        cs.ServeCustomer();

        Console.WriteLine("Serving second customer:");
        cs.ServeCustomer();

        // Defect(s) Found:
        // ServeCustomer removed the first customer before saving it,
        // and then displayed the next customer instead.

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Try to serve a customer from an empty queue.
        // Expected Result: An error message should be displayed
        // instead of the program crashing.
        Console.WriteLine("Test 3");
        cs = new CustomerService(2);

        cs.ServeCustomer();

        // Defect(s) Found:
        // ServeCustomer did not check whether the queue was empty
        // before attempting to access/remove an item.

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Create a queue using an invalid maximum size.
        // Expected Result: Maximum size should default to 10.
        Console.WriteLine("Test 4");
        cs = new CustomerService(0);

        Console.WriteLine(cs);

        // Expected:
        // [size=0 max_size=10 => ]

        // Defect(s) Found:
        // None. The constructor correctly defaults the maximum
        // queue size to 10 when maxSize <= 0.
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.
    /// Put the new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();

        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();

        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        // Check whether the queue is empty
        if (_queue.Count == 0) {
            Console.WriteLine("No Customers in Queue.");
            return;
        }

        // Get the customer at the front of the queue
        var customer = _queue[0];

        // Remove the customer from the front
        _queue.RemoveAt(0);

        // Display the customer that was served
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation
    /// of the customer service queue object.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => "
               + string.Join(", ", _queue) + "]";
    }
}