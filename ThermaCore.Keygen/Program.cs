using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace ThermaCore.Keygen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("  ThermaCore RSA-SHA256 Keygen Tool     ");
            Console.WriteLine("========================================");

            // Step 1: Read Inputs
            Console.Write("Enter Machine HWID (or Mock-Mac-Address for any): ");
            string hwid = Console.ReadLine() ?? "Mock-Mac-Address";
            if (string.IsNullOrWhiteSpace(hwid)) hwid = "Mock-Mac-Address";

            Console.Write("Enter Max Seats (Terminals): ");
            string seatsInput = Console.ReadLine() ?? "1";
            if (!int.TryParse(seatsInput, out int seats)) seats = 1;

            Console.Write("Enter Expiry Date (yyyy-MM-dd): ");
            string dateInput = Console.ReadLine() ?? "";
            if (!DateTime.TryParse(dateInput, out DateTime expiryDate))
            {
                expiryDate = DateTime.Now.AddYears(1);
            }

            // Step 2: Generate RSA Key Pair
            Console.WriteLine("\n[+] Generating 2048-bit RSA Key Pair...");
            using var rsa = new RSACryptoServiceProvider(2048);
            string privateKey = rsa.ToXmlString(true);
            string publicKey = rsa.ToXmlString(false);

            // Print Keys (In a real scenario, private key is kept secret)
            Console.WriteLine("\n--- PUBLIC KEY (Copy to ThermaCore LicenseValidator.cs) ---");
            Console.WriteLine(publicKey);
            Console.WriteLine("-----------------------------------------------------------\n");

            // Step 3: Create Payload
            var payloadObj = new
            {
                Seats = seats,
                ExpiryUtc = expiryDate.ToUniversalTime(),
                MachineFingerprint = hwid
            };

            string payloadJson = JsonSerializer.Serialize(payloadObj);
            byte[] payloadBytes = Encoding.UTF8.GetBytes(payloadJson);
            string payloadBase64 = Convert.ToBase64String(payloadBytes);

            // Step 4: Sign Payload
            byte[] signatureBytes = rsa.SignData(payloadBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            string signatureBase64 = Convert.ToBase64String(signatureBytes);

            // Step 5: Wrap in Final JSON
            var wrapperObj = new
            {
                alg = "RSA-SHA256",
                payload = payloadBase64,
                signature = signatureBase64
            };

            string finalLicenseJson = JsonSerializer.Serialize(wrapperObj, new JsonSerializerOptions { WriteIndented = true });

            Console.WriteLine("--- FINAL LICENSE KEY (Give this to Customer) ---");
            Console.WriteLine(finalLicenseJson);
            Console.WriteLine("-------------------------------------------------");
            
            // Save to Desktop
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string fileName = $"ThermaCoreLicense_{hwid}.lic";
                string fullPath = Path.Combine(desktopPath, fileName);
                File.WriteAllText(fullPath, finalLicenseJson);
                Console.WriteLine($"\n[SUCCESS] License file generated and saved to: {fullPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[ERROR] Failed to save license file to Desktop: {ex.Message}");
            }
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
