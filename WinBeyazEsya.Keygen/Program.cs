using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace WinBeyazEsya.Keygen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("     WinBeyazEsya Lisans Üretici (Keygen) Aracı     ");
            Console.WriteLine("==================================================");
            Console.WriteLine();

            // Adım 1: Kullanıcı Girişleri
            Console.WriteLine("Makine Donanım Kimliği (HWID), lisansın sadece belirtilen cihaza özel olmasını sağlar.");
            Console.WriteLine("Lütfen müşterinin size ilettiği donanım kimliğini birebir aynı kopyalayarak yapıştırın.");
            Console.WriteLine("Örnek HWID Formatı: A1-B2-C3-D4-E5-F6 (Aralarda tire olacak şekilde girilmelidir).");
            Console.WriteLine("NOT: Boş bırakırsanız ('Mock-Mac-Address' atanır), donanım kontrolü devre dışı kalır ve lisans HER cihazda çalışır.");
            Console.Write("\nHWID Giriniz: ");
            string hwid = Console.ReadLine()?.Trim() ?? "Mock-Mac-Address";
            if (string.IsNullOrWhiteSpace(hwid)) hwid = "Mock-Mac-Address";

            Console.Write("Maksimum Terminal/Kullanıcı Sayısı [Varsayılan: 1]: ");
            string seatsInput = Console.ReadLine()?.Trim() ?? "1";
            if (!int.TryParse(seatsInput, out int seats)) seats = 1;

            // Bitiş Tarihi Seçimi Menüsü
            DateTime expiryDate = DateTime.Now.AddYears(1); // Varsayılan 1 yıl
            bool validDateSelected = false;

            while (!validDateSelected)
            {
                Console.WriteLine("\n--- Lisans Süresi Seçimi ---");
                Console.WriteLine("1) 1 Aylık Lisans");
                Console.WriteLine("2) 3 Aylık Lisans");
                Console.WriteLine("3) 6 Aylık Lisans");
                Console.WriteLine("4) 1 Yıllık Lisans");
                Console.WriteLine("5) Sınırsız Lisans (10 Yıl)");
                Console.WriteLine("6) Özel Tarih Gir (GÜN.AY.YIL formatında)");
                Console.Write("Seçiminiz (1-6) [Varsayılan: 4]: ");

                string choice = Console.ReadLine()?.Trim() ?? "4";
                if (string.IsNullOrWhiteSpace(choice)) choice = "4";

                switch (choice)
                {
                    case "1": expiryDate = DateTime.Now.AddMonths(1); validDateSelected = true; break;
                    case "2": expiryDate = DateTime.Now.AddMonths(3); validDateSelected = true; break;
                    case "3": expiryDate = DateTime.Now.AddMonths(6); validDateSelected = true; break;
                    case "4": expiryDate = DateTime.Now.AddYears(1); validDateSelected = true; break;
                    case "5": expiryDate = DateTime.Now.AddYears(10); validDateSelected = true; break;
                    case "6":
                        Console.Write("\nBitiş Tarihini giriniz (GÜN.AY.YIL formatında, Örn: 25.06.2026): ");
                        string customDate = Console.ReadLine()?.Trim() ?? "";
                        
                        string[] formats = { "dd.MM.yyyy", "dd/MM/yyyy", "dd-MM-yyyy" };
                        if (DateTime.TryParseExact(customDate, formats, new System.Globalization.CultureInfo("tr-TR"), System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
                        {
                            expiryDate = parsedDate;
                            validDateSelected = true;
                        }
                        else
                        {
                            Console.WriteLine("\n[HATA] Hatalı tarih formatı girdiniz!");
                            Console.WriteLine("Lütfen aralara nokta koyarak GÜN.AY.YIL şeklinde giriniz (Örnek: 25.06.2026, 25/06/2026 veya 25-06-2026).\n");
                        }
                        break;
                    default:
                        Console.WriteLine("\n[HATA] Geçersiz seçim! Lütfen 1 ile 6 arasında bir değer giriniz.");
                        break;
                }
            }

            Console.WriteLine($"\n[BİLGİ] Geçerli Lisans Bitiş Tarihi: {expiryDate.ToString("dd.MM.yyyy HH:mm")}");

            // Adım 2: Sabit RSA Anahtarı İle İmzalama
            Console.WriteLine("\n[+] Lisans verileri şifreleniyor ve imzalanıyor...");
            string privateKey = @"<RSAKeyValue><Modulus>1KdTdgfVtbluGQk10dBYsO5rfaz53V6hfT7RVU3kGnxo6wmSl2jI6cL5eGA2XHV0j0FM6osUfNGoNq6C+ct2nFKteIo2YkMHs9YLGSWUCR77VqHSq+Lofg3m58D+WI1632L3f4piX/Te2FfOrEyP8O/ZC2o8p4kwq7G0wlqUXn1LrAlEhmQn54iQiBQ6gObwthgZr1Autd4TFl9eOs2srP+BZNlx1k1aMEsAjNNHLJLypVwKhlLoPlbWS1uEjhsMrD8YWBeS9ZceTt5H+/7bPLu8Cr3fjFcpoXnshwHoh+Rgfm8DfR6HfNjZvg6haH6AM7BELCXzWznrBEFhgFbAxQ==</Modulus><Exponent>AQAB</Exponent><P>3HprmcbbC3C3Wfe1tT2VPU/5JIOck/xiUb7+27lossbIt5hDfTcpYDb6GaLftEQ+JKrkuFR6nbVaEG4aU02ngbG8vmhksaPfdfaIqbZGkenET+2N4w5CFpIihCO+b5T7fJIN9uZUALb784IjnpzBDKcJ9XrUjAci8omYaA4Io9M=</P><Q>9uouonNktqeRqiwpKHXqHNjIcpLnSHrpsM2JAvaNP6Syizo9OJ/WtgzQ9tSQv1lB/UAsS6nqRZ0x02BXpqu8ZNSCNg8Db37kvLsTe2iQWkRPknxDsr2tjE2XpXj7bQQ0v9UuYzvt5yJtNWGwLN++86airO8vHoIWDqe8aZJe4gc=</Q><DP>S++uF6yxzOLpg4cZgm7Pc+qTeMwLpbyLcHRD+xGEye5FO1aqB/pzubu1sBa0zbWjYaWqWQJfqOnJN1d0obRhOP4qb7os1DIIyOw8bZdl/uNwxcaf09AZWwTB9pkJAg1iAKmdPahezlA3vsrX0c1TgDQX7gB8LC5ZDwftAgmzWBk=</DP><DQ>ldzDG0RQb3A7P/73qCARTRriZm/1Qo+fgPju3MaKKoOq/kgF2nVhGzOiLP4NMKZbH/uwJuhlUYU8NaA28ukvOj+lHGx2WFi7OjWNeIyZeMAXT8BuUnE/gXWiwgMxDxTLc1dPhVldZrkFca3uAP54ZmfQOogdoDWyb4itGaKGRkc=</DQ><InverseQ>Q84ltGS2/8r20w7JCzqQrUgKAY2Avmk5aRCz7u7BSR9UMs25yS4SolrvnP+sP0oby3F/fUyNvDBpJjQVvT9qlDZn2qBWNjIvhofykr1Zd4aEr0gipc0F4nz8FYaHP+GxpdkwdNvdvL48J482NXS60cC1iXWkO1qO9bZwVYS12Pc=</InverseQ><D>Ie1wS2yElDG5dxUZGRh8jf37+FkYpFDswua6zzlWI0OmGZm1YaK+K02IL8Rp5+Z1akWo1+LIqgFpLRA6pU/o5JfsRUcH1jWLjQ2hR6nPLIVc5D19Nx9EqJffNyp7afVonStVAWw6tcSDqVCZELRGYtJhdojElJY2xa3cgQWillBsqDj2we8srxwccgBxhfP4+SPMQkSW+pSjPtq65pP0i29l7ENr+xeAtsLSsxbJWhJOaup9aEJ5VoVSmstH6OIvm/B5yOc06cXtAXIDzfUJFvWAq0QHoELkJRVLK8XC4ZqsB2d1zaFVduXi+W5ZowU/sprxu99sbtTmeVh0u+2XIQ==</D></RSAKeyValue>";
            
            using var rsa = new RSACryptoServiceProvider(2048);
            rsa.FromXmlString(privateKey);

            Console.Write("\nZaman manipülasyonu sıfırlansın mı? (E/H) [Varsayılan: H]: ");
            string resetInput = Console.ReadLine()?.Trim().ToUpper() ?? "H";
            bool resetTimeCheat = resetInput == "E";

            // Adım 3: Payload Oluşturma
            var payloadObj = new
            {
                Seats = seats,
                ExpiryUtc = expiryDate.ToUniversalTime(),
                MachineFingerprint = hwid,
                ResetTimeCheat = resetTimeCheat
            };

            string payloadJson = JsonSerializer.Serialize(payloadObj);
            byte[] payloadBytes = Encoding.UTF8.GetBytes(payloadJson);
            string payloadBase64 = Convert.ToBase64String(payloadBytes);

            // Adım 4: Payload İmzalama
            byte[] signatureBytes = rsa.SignData(payloadBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            string signatureBase64 = Convert.ToBase64String(signatureBytes);

            // Adım 5: Nihai JSON Çıktısı (Wrapper)
            var wrapperObj = new
            {
                alg = "RSA-SHA256",
                payload = payloadBase64,
                signature = signatureBase64
            };

            string finalLicenseJson = JsonSerializer.Serialize(wrapperObj, new JsonSerializerOptions { WriteIndented = true });

            Console.WriteLine("\n------------------ MÜŞTERİYE VERİLECEK LİSANS ANAHTARI ------------------");
            Console.WriteLine(finalLicenseJson);
            Console.WriteLine("-------------------------------------------------------------------------");

            // Masaüstüne Kaydetme İşlemi
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string fileName = $"WinBeyazEsya_Lisans_{hwid}.lic";
                string fullPath = Path.Combine(desktopPath, fileName);
                File.WriteAllText(fullPath, finalLicenseJson, Encoding.UTF8);
                Console.WriteLine($"\n[BAŞARILI] Lisans dosyası masaüstüne kaydedildi:\nDosya Yolu: {fullPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[HATA] Lisans dosyası masaüstüne kaydedilemedi: {ex.Message}");
            }
            
            Console.WriteLine("\nÇıkmak için herhangi bir tuşa basınız...");
            Console.ReadKey();
        }
    }
}

