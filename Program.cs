using ConsoleApp2.Manager;
using System;

class Program
{
    static void Main(string[] args)
    {
        ClientManager clientMgr = new ClientManager();
        Console.WriteLine(">>>>>>>>>>> Welcome! <<<<<<<<<<<");
        string? userInput = "";
        while (true)
        {
            ShowMainMenu();
            userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    clientMgr.ShowClientMenu();
                    break;
                case "2":
                    Console.WriteLine("This has not been implemented yet.");
                    break;
                case "q":
                    Console.WriteLine("Bye!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("I do not understand your input. Please retry.");
                    break;
            }
        }
    }

    private static void ShowMainMenu()
    {
        Console.WriteLine("---- Main Menu ----");
        Console.WriteLine("Please press: ");
        Console.WriteLine("1 to enter the Client menu");
        Console.WriteLine("2 to enter the Equipment menu");
        // add as many options as you need
        Console.WriteLine("q to exit the application");
    }
}