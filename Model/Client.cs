using System.ComponentModel.DataAnnotations;

namespace ConsoleApp2.Model
{
    public class Client
    {
        //[Required]
        [LengthAttribute(6,6)]
        public string? Ref {  get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string TVA { get; set; } = "";

        public Client() { }
        public Client(string reference, string name, string address, string phone)
        {
            Ref = reference.Trim(); 
            Name = name.Trim();
            Name = char.ToUpper(Name[0]) + Name.Substring(1);           // to capitalize
            Address = address.Trim(); 
            Phone = phone.Trim();
        }

        public Client(string reference, string name, string address, string phone, string tva)
        {
            Ref = reference;
            Name = name;
            Address = address;
            Phone = phone;
            TVA = tva;
        }

    }
}
