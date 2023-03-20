namespace CriandoAgenda
{
    internal class Contact
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Contact(string name, string phone, string email)
        {
            Name = name;
            Address = new Address();
            Phone = phone;
            Email = email;
        }

        public void EditName(string name)
        {
            Name = name;
        }

        public void EditPhone (string phone)
        {
            Phone = phone;
        }

        public void EditEmail (string email)
        {
            Email = email;
        }

        public void EditAddress (Address address)
        {
            Address = address;
        }

        public override string ToString()
        {
            if (Email == null)
            {
                return $"Name: {Name} | Address : {Address} \nPhone: {Phone}";
            }
            return $"Name: {Name} | Address : {Address} \nPhone: {Phone} | Email: {Email}";
        }
    }
}
