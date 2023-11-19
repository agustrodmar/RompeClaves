using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        string myPassword = "cQw49yt5ZvVnO+lWVnrVS9Tr7n0HXnFQUiujoIkhu6M=";
        string path = "./2151220-passwords.txt"; 

        try
        {
            // Lee el archivo y lo muestra línea por línea.
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string hashedPassword = ComputeSha256Hash(line);
                    if (hashedPassword == myPassword)
                    {
                        Console.WriteLine(line);
                        break;
                    }
                }
            }
        }
        catch (Exception e)
        {
            // Muestra mensaje de error si no se puede leer el archivo
            Console.WriteLine("El archivo no se puede leer:");
            Console.WriteLine(e.Message);
        }
    }

    static string ComputeSha256Hash(string rawData)
    {
        // Crear un objeto SHA256   
        using (SHA256 sha256Hash = SHA256.Create())
        {
            // CalcularHash   
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            // Convertir byte array a string de base64   
            string hashed = Convert.ToBase64String(bytes);

            return hashed;
        }
    }
}
