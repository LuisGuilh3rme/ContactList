using CriandoAgenda;
List<Contact> phoneBook = new List<Contact>();

do
{
    int op = Menu();

    Console.Clear();
    Console.WriteLine();

    switch (op)
    {
        // Inserir contato
        case 1:
            CreateContact(phoneBook);
            break;

        // Editar contato
        case 2:
            EditContact(phoneBook);
            break;

        // Visualizar contatos
        case 3:
            AllContacts(phoneBook);
            break;

        // Pesquisar contatos
        case 4:
            SearchContact(phoneBook);
            break;

        // Remover contato
        case 5:
            DeleteContact(phoneBook);
            break;

        // Sair do programa
        case 6:
            AllContacts(phoneBook);
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }
} while (true);

int Menu()
{
    Console.Clear();

    Console.WriteLine("MENU DE OPÇÕES");
    Console.WriteLine("1 - Inserir contato");
    Console.WriteLine("2 - Editar contato");
    Console.WriteLine("3 - Visualizar contatos");
    Console.WriteLine("4 - Pesquisar contatos");
    Console.WriteLine("5 - Remover contato");
    Console.WriteLine("6 - Sair");
    int.TryParse(Console.ReadLine(), out int opt);

    return opt;
}

void CreateContact(List<Contact> contacts)
{
    Console.WriteLine("CRIAR CONTATO (Não se pode repetir telefone)");
    Console.WriteLine("Informe o nome: ");
    string name = Console.ReadLine();
    Console.WriteLine("Informe o número: ");
    string phone = Console.ReadLine();
    Console.WriteLine("Informe o email: ");
    string email = Console.ReadLine();
    Contact newContact = new Contact(name, phone, email);

    Console.WriteLine();

    if (contacts.Find(contact => contact.Phone == newContact.Phone) != null)
    {
        Console.WriteLine("Número de telefone já existente");
    }
    else
    {
        contacts.Add(newContact);
        contacts = contacts.OrderBy(contact => contact.Name).ToList();
        Console.WriteLine("Contato criado");
    }

    Console.WriteLine("Aperte ENTER para continuar");
    Console.ReadLine();
}

void DeleteContact(List<Contact> contacts)
{
    Console.WriteLine("DELEÇÃO DE CONTATO");
    Console.WriteLine("Informe o nome: ");
    string name = Console.ReadLine();

    Contact contact = ReturnOneContact(contacts, name);

    Console.WriteLine();

    if (contact == null)
    {
        Console.WriteLine("Nenhum contato encontrado");
    }
    else
    {
        contacts.Remove(contact);
        Console.WriteLine("Contato deletado!");
    }

    Console.WriteLine("Aperte ENTER para continuar");
    Console.ReadLine();
}

void EditContact(List<Contact> contacts)
{
    Console.WriteLine("EDITAR CONTATO");
    Console.WriteLine("Insira o nome do contato: ");
    string name = Console.ReadLine();

    Contact contactResult = ReturnOneContact(contacts, name);

    Console.WriteLine();

    if (contactResult == null)
    {
        Console.WriteLine("Contato não encontrado");
    }
    else
    {
        Console.WriteLine("Contato encontrado");
        int index = contacts.IndexOf(contactResult);

        Console.WriteLine("Digite o nome: ");
        string newName = Console.ReadLine();

        Console.WriteLine("Digite o telefone: ");
        string newPhone = Console.ReadLine();
        if (contacts.Find(contact => contact.Phone == newPhone) != null)
        {
            Console.WriteLine("Número de telefone já existente");
        }
        else
        {
            Console.WriteLine("Digite o email: ");
            string newEmail = Console.ReadLine();

            contacts[index].EditName(newName);
            contacts[index].EditPhone(newPhone);
            contacts[index].EditEmail(newEmail);

            contacts = contacts.OrderBy(contact => contact.Name).ToList();
            Console.WriteLine("Contato editado com sucesso!");
        }
    }
    Console.WriteLine("Aperte ENTER para continuar");
    Console.ReadLine();
}

void AllContacts(List<Contact> contacts)
{
    Console.WriteLine("CONTATOS ENCONTRADOS: ");
    if (contacts.Count > 0)
    {
        Console.Write("PADRÃO: NOME - TELEFONE - EMAIL\n\n");
    }
    else Console.WriteLine("Lista vazia :(");

    foreach (var contact in contacts)
    {
        Console.WriteLine("{0}", contact);
    }

    Console.WriteLine();
    Console.WriteLine("Aperte ENTER para continuar");
    Console.ReadLine();
    Console.WriteLine();
}

List<Contact> FindContactsByName(List<Contact> contacts, string name)
{
    return contacts.FindAll(contact => contact.Name.ToLower() == name.ToLower());
}

Contact ReturnOneContact(List<Contact> contacts, string name)
{
    List<Contact> contactResult = FindContactsByName(contacts, name);
    Contact searchedContact = null;

    if (contactResult.Count == 0) return null;
    if (contactResult.Count == 1) return contactResult[0];

    int index = 0;
    do
    {

        Console.WriteLine("PADRÃO: Número - NOME - TELEFONE - EMAIL\n");
        int count = 0;
        foreach (var contact in contactResult)
        {
            Console.WriteLine(" {0}) {1}", ++count, contact);
        }
        Console.WriteLine();
        Console.Write("Há mais de um contato, insira o número do índice do contato desejado: ");
        int.TryParse(Console.ReadLine(), out index);


        if (index > count || index < 1)
        {
            Console.WriteLine("Indíce inválido");
            index = -1;
        }
        else searchedContact = contactResult[index - 1];
    } while (index == -1);
    return searchedContact;
}

void SearchContact(List<Contact> contacts)
{
    Console.WriteLine("PESQUISAR CONTATOS");
    Console.WriteLine("Tipo de pesquisa:");
    int opt;

    do
    {
        Console.WriteLine("1 - Por nome");
        Console.WriteLine("2 - Por telefone");
        Console.WriteLine("3 - Por email");
        int.TryParse(Console.ReadLine(), out opt);

        if (opt != 1 && opt != 2 && opt != 3)
        {
            Console.Clear();
            Console.WriteLine("Opção inválida");
            opt = 0;

            Console.WriteLine("Aperte ENTER para continuar");
            Console.ReadLine();
        }
    } while (opt == 0);

    Console.WriteLine();

    List<Contact> searchedContacts;

    switch (opt)
    {
        case 1:
            Console.Write("Insira o nome: ");
            string name = Console.ReadLine();
            searchedContacts = contacts.FindAll(contact => contact.Name.ToLower().Contains(name.ToLower()));
            break;
        case 2:
            Console.Write("Insira o telefone: ");
            string phone = Console.ReadLine();
            searchedContacts = contacts.FindAll(contact => contact.Phone.Contains(phone));
            break;
        case 3:
            Console.Write("Insira o email: ");
            string email = Console.ReadLine();
            searchedContacts = contacts.FindAll(contact => contact.Email.ToLower().Contains(email.ToLower()));
            break;
        default:
            searchedContacts = null;
            break;
    }

    if (searchedContacts == null)
    {
        Console.WriteLine("Nenhum contato encontrado");
        Console.WriteLine("Aperte ENTER para continuar");
        Console.ReadLine();
    }

    else AllContacts(searchedContacts);
}