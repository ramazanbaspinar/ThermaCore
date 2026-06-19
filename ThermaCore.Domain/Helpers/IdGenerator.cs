using System;

namespace ThermaCore.Domain.Helpers;

public static class IdGenerator
{
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
        var random = SifirEkle(new Random().Next(0, 99).ToString());

        return long.Parse(yil + ay + gun + saat + dakika + saniye + milisaniye + random);
    }
}
