// a list is a resizable container
List<Account> acccounts = new List<Account>();


accounts.Add(new Account { Name = "Alice", Balance = 1000.00m });)



Console.WriteLine($"Account Name: {accountName}, Balance: {balance}");


//menu

//running (basically is going to show if menu should be on screen or not)
bool running = true;

// our main loop
while (running)
{
    Console.WriteLine("\n1. Check Balance\n2. Deposit Sum\n3. Withdraw Cash\n4. Exit Menu");

    // taking user input
    Console.Write("Choose: ");

    // read whatever the user types
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.WriteLine($"Balance: {balance}");
            break;

        case "2":
            Console.Write("Enter deposit amount: ");

            //decimal
            decimal dep = decimal.Parse(Console.ReadLine());

            if (dep > 0)
            {
                balance += dep;
                Console.WriteLine($"Deposited: {dep}, New Balance is: {balance}");

            }
            else Console.WriteLine("Enter a positive amount.");

            break;
        case "3":
            Console.Write("Enter amount: ");
            decimal withdraw = decimal.Parse(Console.ReadLine());

            if (withdraw > 0)
            {
                if (withdraw <= balance)
                {
                    balance -= withdraw;
                    Console.WriteLine($"Withdrew: {withdraw}, New Balance is: {balance}");
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
            Console.WriteLine("Exiting menu...");
            running = false;
            break;

        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}