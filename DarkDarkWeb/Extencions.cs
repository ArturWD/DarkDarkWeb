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

        public static string[] GetKeywordsString(this string keywords)
        {
            string[] stringSeparators = new string[] { ",", ";", ".", ":", "-", "|", " " };
            return  keywords.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string ToMonthName(this DateTime dateTime)
        {
            CultureInfo ci = new CultureInfo("en-US");
            return DateTime.Now.ToString("MMMM", ci);
        }

        public static List<Resource> Search(this List<Resource> resources, string keywordsString)
        {
            var searchedKeywords = keywordsString.GetKeywordsString();
            var foundresources = new List<Resource>();
            for (int i = keywordsString.Count(); i>0; i--)
            {
                foreach(var r in resources)
                {
                    if (r.Keywords.HowManyKeywords(searchedKeywords) == i) foundresources.Add(r);
                }
            }
            return resources;
        }
        private static int HowManyKeywords(this IEnumerable<Keyword> containedKeywords, string[] searchedKeywords)
        {
            int i = 0;
            foreach(var word in searchedKeywords)
            {
                if (containedKeywords.Select(k => k.KeywordName).ToList().Contains(word)) i++;
            }
            return i;
        }
    }
}