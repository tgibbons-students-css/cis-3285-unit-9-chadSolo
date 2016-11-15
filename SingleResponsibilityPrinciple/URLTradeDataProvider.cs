using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class URLTradeDataProvider : ITradeDataProvider
    {
        public StreamTradeDataProvider(string url)
        {
            this.url = url;
        }

        public IEnumerable<string> GetTradeData(string url)
        {
            //string url = "http://faculty.css.edu/tgibbons/trades4.txt";
            var tradeData = new List<string>();
            var client = new WebClient();
            using (var stream = client.OpenRead(url))
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    tradeData.Add(line);
                }
            }
            return tradeData;

        }

        public IEnumerable<string> GetTradeData()
        {
            throw new NotImplementedException();
        }
    }
}
