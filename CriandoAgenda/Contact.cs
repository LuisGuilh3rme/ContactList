namespace CriandoAgenda
{
    internal class Contact
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Contact(string name, string phone, string email)
        {
            Name = name;
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

        public override string ToString()
        {
            if (Email == null)
            {
                return $"Name: {Name} | Phone: {Phone}";
            }
            return $"Name: {Name} | Phone: {Phone} | Email: {Email}";
        }
    }
}
