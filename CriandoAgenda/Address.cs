namespace CriandoAgenda
{
    internal class Address
    {
        public string Street;
        public string City;
        public string State;
        public string PostalCode;
        public string Country;

        public Address()
        {

        }

        public void EditStreet(string street)
        {
            Street = street;
        }

        public void EditCity (string city)
        {
            City = city;
        }
        
        public void EditState (string state)
        {
            State = state;
        }

        public void EditCountry (string country)
        {
            Country = country;
        }

        public override string ToString()
        {
            return "Endereço: " + Street + "\nCidade: " + City + "\nEstado: " + State + "\nCódigo Postal: " + PostalCode + "\nPaís: " + Country;
        }
    }
}
