using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ReadKey();
        }

       
        public void DateParsingTest()
        {
            var dt = DateTime.Now.ToString("d/MM/yyyy");
            Console.WriteLine(dt);

            DateTime dt2 = DateTime.Now; ;
            bool tparse = DateTime.TryParse("26/08/2020", out dt2);
            if (tparse == false) dt2 = DateTime.Now - TimeSpan.FromDays(1);
            Console.WriteLine(dt2.ToString("d/MM/yyyy"));
            Console.ReadKey();

        }

        public static void DictionaryTest()
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < 50; i++)
            {
                dict[i] = i;
            }
            foreach (var item in dict)
            {
                Console.WriteLine($"Key:{item.Key},Value:{item.Value}");
            }
            List<KeyValuePair<int, int>> list1 = new List<KeyValuePair<int, int>>();
            list1 = dict.ToList();
            Console.WriteLine($"list1.Count:{list1.Count}");
            Console.WriteLine($"index5:{list1[5].Key}, value{list1[5].Value}");
            Console.ReadKey();
        }
    
        public void enqueueTest()
        {
            var dateAndTime = DateTime.Now;
            Console.WriteLine(dateAndTime);
            var date = dateAndTime.Date;
            Console.WriteLine(date);
            date += TimeSpan.FromDays(1);
            Console.WriteLine(date);
            Console.ReadKey();
            Queue myQueue = new Queue();
        }
        public void obterDataPorExtenso()
        {
            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;

            int dia = DateTime.Now.Day;
            int ano = DateTime.Now.Year;
            string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(DateTime.Now.Month));
            string diasemana = culture.TextInfo.ToTitleCase(dtfi.GetDayName(DateTime.Now.DayOfWeek));
            string data = diasemana + ", " + dia + " de " + mes + " de " + ano;
            Console.WriteLine(data);
            Console.ReadKey();
        }
        public static string GetNewsFromServer(string url)
        {
            try
            {
                // Create a new XmlTextReader from the specified URL (RSS feed)
                XmlTextReader rssReader = new XmlTextReader(url);
                XmlDocument rssDoc = new XmlDocument();
                XmlNode nodeRss = null;
                XmlNode nodeChannel = null;
                XmlNode nodeItem = null;

                string str = string.Empty;

                // Load the XML content into a XmlDocument
                rssDoc.Load(rssReader);

                for (int i = 0; i < rssDoc.ChildNodes.Count; i++)
                {
                    if (rssDoc.ChildNodes[i].Name == "rss")
                    {
                        nodeRss = rssDoc.ChildNodes[i];
                    }
                }
                for (int i = 0; i < nodeRss.ChildNodes.Count; i++)
                {
                    if (nodeRss.ChildNodes[i].Name == "channel")
                    {
                        nodeChannel = nodeRss.ChildNodes[i];
                    }
                }
                for (int i = 0; i < nodeChannel.ChildNodes.Count; i++)
                {
                    if (nodeChannel.ChildNodes[i].Name == "item")
                    {
                        nodeItem = nodeChannel.ChildNodes[i];
                        string s = nodeItem["title"].InnerText + " - ";
                        s += nodeItem["description"].InnerText;
                        str += s + "|";
                    }
                }
                return str;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        public void GetNews()
        {
            string news = GetNewsFromServer(@"https://www.noticiasaominuto.com/rss/ultima-hora") + " Desenvolvido por www.enginis.com";
            string[] newsArray = news.Split('|');
            foreach (var item in newsArray)
            {
                Console.WriteLine(item);
                Console.WriteLine("");
                Console.WriteLine("");
            }

            Console.ReadKey();
        }
    }
    
}
