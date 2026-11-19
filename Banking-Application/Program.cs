// a list is a resizable container
List<Account> accounts = new List<Account>();


accounts.Add(new Account { Name = "Alice", Balance = 100.00m });
accounts.Add(new Account { Name = "Bob", Balance = 700.00m });

// login
Console.Write("Enter your name: ");
string loginName = Console.ReadLine();

// finding the account inside the list and returning the name who matches
Account current = accounts.Find(a => a.Name == loginName);

if (current == null)
{
    current = new Account { Name = loginName, Balance = 0.00m };
    accounts.Add(current);
    Console.WriteLine($"New account created for {loginName}");
}

//menu

//running (basically is going to show if menu should be on screen or not)
bool running = true;

// our main loop
while (running)
{
    Console.WriteLine("\n1. Check Balance\n2. Deposit Sum\n3. Withdraw Cash\n4. Transfer Balance\n5. Transaction History\n6. Exit");

    // taking user input
    Console.Write("Choose: ");

    // read whatever the user types
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.WriteLine($"Balance: {current.Balance}");
            break;

        case "2":
            Console.Write("Enter deposit amount: ");

            //decimal
            decimal dep = decimal.Parse(Console.ReadLine());

            if (dep > 0)
            {
                current.Balance += dep;
                Console.WriteLine($"Deposited: {dep}, New Balance is: {current.Balance}");
                current.History.Add($"Deposited {dep}");

            }
            else Console.WriteLine("Enter a positive amount.");

            break;
        case "3":
            Console.Write("Enter amount: ");
            decimal withdraw = decimal.Parse(Console.ReadLine());

            if (withdraw > 0)
            {
                if (withdraw <= current.Balance)
                {
                    current.Balance -= withdraw;
                    Console.WriteLine($"Withdrew: {withdraw}, New Balance is: {current.Balance}");
                    current.History.Add($"Withdrew {withdraw}");

                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                }
            }
            else
            {
                Console.WriteLine("Enter a positive amount.");
            }
            break;

        case "4":
            Console.Write("Send to (name): ");
            string targetName = Console.ReadLine();

            Account target = accounts.Find(a => a.Name == targetName);

            if (target == null)
            {
                Console.WriteLine("Receiver does not exist.");
                break;
            }

            Console.Write("Enter amount: ");
            decimal amt = decimal.Parse(Console.ReadLine());

            if (amt > 0 && amt <= current.Balance)
            {
                current.Balance -= amt;
                target.Balance += amt;
                Console.WriteLine($"Transferred {amt} to {target.Name}. New Balance is: {current.Balance}");
                current.History.Add($"Transferred {amt} to {target.Name}");
                target.History.Add($"Received {amt} from {current.Name}");
            }
            else Console.WriteLine("Invalid transfer amount.");

            break;

        case "5":
            Console.WriteLine($".....{current.Name}'s History ..... ");

            // foreach loop

            foreach (string entry in current.History)
                Console.WriteLine(entry);
            break;

        case "6":
            Console.WriteLine("Exiting menu...");
            running = false;
            break;

        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}

// The blueprint
class Account
{
    public string Name { get; set; }
    public decimal Balance { get; set; }

    // new() starts it as an empty list
    public List<string> History { get; set } = new();
}