using System;

namespace WinBeyazEsya.Domain.Helpers;

public static class IdGenerator
{
    private static long _lastId = 0;
    private static readonly object _lock = new object();

    public static long GenerateId()
    {
        lock (_lock)
        {
            var now = DateTime.Now;
            // yyyyMMddHHmmssfff + 00 (toplam 19 hane, long sınırları içerisinde)
            long baseId = long.Parse(now.ToString("yyyyMMddHHmmssfff") + "00");
            
            if (baseId <= _lastId)
            {
                _lastId++;
            }
            else
            {
                _lastId = baseId;
            }
            
            return _lastId;
        }
    }
}

