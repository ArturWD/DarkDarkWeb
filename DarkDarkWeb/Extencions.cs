using DDW.Core.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace DarkDarkWeb
{
    public static class Extencions
    {
        public static ICollection<Keyword> GetKeywords(this string keywords)
        {
            string[] stringSeparators = new string[] { ",", ";", ".", ":", "-", "|"," " };
            var keywordsText = keywords.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            List<Keyword> keywordsCollection = new List<Keyword>();
            foreach (var item in keywordsText) keywordsCollection.Add(new Keyword { KeywordName=item.ToLower()});
            return keywordsCollection;
        }

        public static string ToMonthName(this DateTime dateTime)
        {
            CultureInfo ci = new CultureInfo("en-US");
            return DateTime.Now.ToString("MMMM", ci);
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTime.Month);
        }
    }
}