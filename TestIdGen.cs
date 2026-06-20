using System;
using System.Collections.Generic;

namespace TestApp
{
    public static class IdGenerator
    {
        private static int _counter = 0;
        private static readonly object _lock = new object();

        public static long GenerateId()
        {
            string SifirEkle(string deger)
            {
                if (deger.Length == 1)
                    return "0" + deger;
                return deger;
            }

            string UcBasamakliYap(string deger)
            {
                switch (deger.Length)
                {
                    case 1:
                        return "00" + deger;
                    case 2:
                        return "0" + deger;
                }

                return deger;
            }

            var yil = DateTime.Now.Date.Year.ToString();
            var ay = SifirEkle(DateTime.Now.Date.Month.ToString());
            var gun = SifirEkle(DateTime.Now.Date.Day.ToString());
            var saat = SifirEkle(DateTime.Now.Hour.ToString());
            var dakika = SifirEkle(DateTime.Now.Minute.ToString());
            var saniye = SifirEkle(DateTime.Now.Second.ToString());
            var milisaniye = UcBasamakliYap(DateTime.Now.Millisecond.ToString());
            
            string seqPart;
            lock (_lock)
            {
                _counter++;
                if (_counter > 99) 
                {
                    _counter = 0;
                    System.Threading.Thread.Sleep(1);
                }
                seqPart = SifirEkle(_counter.ToString());
            }

            return long.Parse(yil + ay + gun + saat + dakika + saniye + milisaniye + seqPart);
        }
    }

    class Program
    {
        static void Main()
        {
            var ids = new HashSet<long>();
            int duplicates = 0;
            for (int i = 0; i < 200; i++)
            {
                long id = IdGenerator.GenerateId();
                if (!ids.Add(id))
                {
                    duplicates++;
                    Console.WriteLine("Duplicate found! " + id);
                }
            }
            Console.WriteLine("Total duplicates: " + duplicates);
        }
    }
}
