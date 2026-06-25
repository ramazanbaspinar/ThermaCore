using System;
using System.Security.Cryptography;

public class Program
{
    public static void Main()
    {
        using (var rsa = new RSACryptoServiceProvider(2048))
        {
            Console.WriteLine("PRIVATE:");
            Console.WriteLine(rsa.ToXmlString(true));
            Console.WriteLine("PUBLIC:");
            Console.WriteLine(rsa.ToXmlString(false));
        }
    }
}
