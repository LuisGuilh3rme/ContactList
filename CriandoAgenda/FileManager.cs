namespace CriandoAgenda
{
    internal class FileManager
    {
        static string Path = @"C:\\Users\\" + Environment.UserName + @"\\Documents\\";
        public string FullPath { get; private set; }
        private StreamWriter _sw;
        private StreamReader _sr;

        public FileManager(string fileName)
        {
            FullPath = Path + fileName + ".ecl";
        }

        public void CreateFile(List<Contact> contacts)
        {
            _sw = new StreamWriter(FullPath);

            for (int i = 0; i < contacts.Count; i++)
            {
                _sw.WriteLine(contacts[i]);
            }

            _sw.Close();
        }

        public void AppendFile(List<Contact> contacts)
        {
            _sw = File.AppendText(FullPath);

            for (int i = 0; i < contacts.Count; i++)
            {
                _sw.WriteLine(contacts[i]);
            }

            _sw.Close();
        }

        public List<Contact> LoadFile()
        {
            List<Contact> contacts = new List<Contact>();
            _sr = new StreamReader(FullPath);

            string line = _sr.ReadLine();

            string[] objCreator;
            while (line != null)
            {
                objCreator = line.Split('|');
                for (int i = 0; i < objCreator.Length; i++)
                {
                    int index = objCreator[i].IndexOf(':');
                    objCreator[i] = objCreator[i].Substring(index + 1);
                }
                contacts.Add(new Contact(objCreator[0], objCreator[1], objCreator[2]));
                line = _sr.ReadLine();
            }

            return contacts;
        }

        public bool FileExists()
        {
            return File.Exists(FullPath);
        }
    }
}
