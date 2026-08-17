using System;
using System.Text.RegularExpressions;

namespace WinBeyazEsya.Domain.Helpers;

public static class PhoneDataParser
{
    public static (string? CleanPhone, bool HasExtraData) Parse(string? rawData)
    {
        if (string.IsNullOrWhiteSpace(rawData))
            return (null, false);

        // Remove everything except digits
        var digitRegex = new Regex(@"[^\d]");
        string digitsOnly = digitRegex.Replace(rawData, "");

        // Find the first valid 10 or 11 digit number
        // We will look for 11 digits starting with 0, or 10 digits
        var phoneMatch = Regex.Match(digitsOnly, @"(05\d{9}|0\d{10}|5\d{9}|\d{10})");
        
        string? cleanPhone = null;
        if (phoneMatch.Success)
        {
            cleanPhone = phoneMatch.Value;
        }
        else if (digitsOnly.Length >= 10)
        {
            // Fallback just grab the first 10 or 11
            cleanPhone = digitsOnly.StartsWith("0") ? digitsOnly.Substring(0, Math.Min(11, digitsOnly.Length)) : digitsOnly.Substring(0, Math.Min(10, digitsOnly.Length));
        }
        else if (digitsOnly.Length > 0)
        {
             cleanPhone = digitsOnly; // Even if it's less than 10 digits, we extracted digits.
        }

        // Check if there's any extra data. 
        var letterRegex = new Regex(@"[a-zA-ZçğıöşüÇĞİÖŞÜ]");
        bool hasLetters = letterRegex.IsMatch(rawData);
        bool hasExtraDigits = cleanPhone != null && digitsOnly.Length > cleanPhone.Length;

        bool hasExtraData = hasLetters || hasExtraDigits;

        return (cleanPhone, hasExtraData);
    }
}
