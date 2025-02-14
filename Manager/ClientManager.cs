using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2.Model;

namespace ConsoleApp2.Manager
{
    public class ClientManager
    {
        private Dictionary<string, Client> _clients {  get; set; }

        public void ShowClientMenu()
        {
            while (true)
            {
                Console.WriteLine("---- Client Menu -----");
                Console.WriteLine("Please press: ");
                Console.WriteLine("1 to add a client");
                Console.WriteLine("2 to modify a client");
                Console.WriteLine("3 to remove a client");
                Console.WriteLine("4 to search for a client");
                Console.WriteLine("5 to show all client information");
                Console.WriteLine("0 to go back to main menu");
                Console.WriteLine("q to exit the application");
                string? input = Console.ReadLine()?.Trim();
                switch (input)
                {
                    case "1":
                        AddClient();
                        break;
                    case "2":
                        ModifyClient();
                        break;
                    case "3":
                        RemoveClient();
                        break;
                    case "4":
                        ShowClient();
                        break;
                    case "5":
                        ShowAll();
                        break;
                    case "0":
                        return;
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
        public void AddClient()
        {
            Client client = new Client();
            Console.WriteLine("> Please enter your client refence, it must be 6-digit long:");
            client.Ref = Console.ReadLine().Trim();
            Console.WriteLine("> Please enter your client name");
            client.Name = Console.ReadLine().Trim();
            Console.WriteLine("> Please enter your client phone");
            client.Phone = Console.ReadLine().Trim();
            Console.WriteLine("> Please enter your client address");
            client.Address = Console.ReadLine().Trim();
            Console.WriteLine("> Please enter your client TVA number (or leave this field empty)");
            client.TVA = Console.ReadLine().Trim();
            if (NoErrorOnCreation(client))
            {
                Console.WriteLine($"> Client {client.Name} successfully added");
                _clients.Add(client.Ref, client);
            }
        }

        // to be think of
        public void ModifyClient()
        {
            Console.WriteLine("> Please enter the ref number of the client to modify");
            string refNo = Console.ReadLine().Trim();
            Client client = FindClient(refNo);
            if (client != null) {
                Console.WriteLine("> Please press 1 to modify the ref number, 2 to modify the name, 3 to modify the phone,\n> 4 to modify the address or 5 to modify the TVA");
                string type = Console.ReadLine().Trim();
                Console.WriteLine("> Got it, now enter the new value for the selected field:");
                string newParam = Console.ReadLine().Trim();
                switch (type)
                {
                    case "1":
                        if (_clients.ContainsKey(newParam))
                        {
                            Console.WriteLine("> Sorry, this ref number already exists and client cannot be modified.");
                            return;
                        }
                        string oldRef = client.Ref;
                        client.Ref = newParam;
                        _clients.Remove(oldRef);
                        _clients.Add(newParam, client);
                        break;
                    case "2":
                        _clients[client.Ref].Name = newParam;
                        break;
                    case "3":
                        _clients[client.Ref].Phone = newParam;
                        break;
                    case "4":
                        _clients[client.Ref].Address = newParam;
                        break;
                    case "5":
                        _clients[client.Ref].TVA = newParam;
                        break;
                    default:
                        Console.WriteLine("> Sorry this field does not exist, client could not be modified.");
                        return;
                }
                Console.WriteLine($"> Client successfully modified with value {newParam}");
            }
        }

        public void RemoveClient()
        {
            Console.WriteLine("> Enter the ref number of the client to remove");
            string input = Console.ReadLine().Trim();
            if (_clients.Remove(input))
            {
                Console.WriteLine($"> Client with ref number {input} has been successfully removed");
                return  ;
            }
            Console.WriteLine($"> Client with ref number {input} could not be found. Nothing to remove");
        }

        public Client? FindClient(string param)
        {
            foreach (Client c in _clients.Values)
            {
                if (c.Ref == param || c.Name == param ||
                    c.Address == param || c.Phone == param || c.TVA == param)
                {
                    return c;
                }
            };
            Console.WriteLine($"> No client found with parameter {param}. Retry.");
            return null;
        }

        public void ShowClient()
        {
            Console.WriteLine("> Enter the param to look for in a client");
            string param = Console.ReadLine().Trim();
            bool notFound = true;
            foreach (Client c in _clients.Values)
            { 
                // utiliser string.Contains() si on veut des match partiels
                // utiliser == si on veut un match total, ex. c.Name == param
                if (c.Ref.Contains(param) || c.Name.Contains(param) ||
                    c.Address.Contains(param) || c.Phone.Contains(param) || c.TVA.Contains(param) )
                {
                    notFound = false;
                    PrintOutClientInfo(c);
                }
            };
            if (notFound)
                Console.WriteLine($"> No client found with parameter {param}. Retry.");
        }
        public void ShowAll()
        {
            if (_clients.Keys.Count() == 0)
            {
                Console.WriteLine("> No clients added yet");
                return;
            }
            foreach (Client c in _clients.Values)
                PrintOutClientInfo(c);
        }
        public ClientManager() 
        { 
            _clients = new Dictionary<string, Client>();
        }

        private bool NoErrorOnCreation(Client client)
        {
            if (_clients.ContainsKey(client.Ref))
            {
                Console.WriteLine("> A client with this reference number already exists. Client cannot be added.");
                return false;
            }
            if (client.Ref.Trim().Length == 6 && client.Ref.Trim().All(char.IsDigit)) // add Trim() to remove whitespaces in front or end of input
            {
                return true;
            }
            // ajouter d'autres verification si nécéssaire + message d'erreur
            Console.WriteLine("> !!! Reference should be 6-digit long and contains numbers ONLY.\n> No client added, please retry.");
            return false;
        }

        private void PrintOutClientInfo(Client client)
        {
            foreach (Client c in _clients.Values)
            {
                Console.WriteLine($"---- Client Ref: {c.Ref} ----");
                Console.WriteLine($"> Name: {c.Name}");
                Console.WriteLine($"> Address: {c.Address}");
                Console.WriteLine($"> Phone: {c.Phone}");
                Console.WriteLine($"> TVA: " + (string.IsNullOrEmpty(c.TVA) ? "no TVA present" : c.TVA));
            };
        }
    }
}
