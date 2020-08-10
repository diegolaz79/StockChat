using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace StockChat
{
    public class StockBot
    {
        public StockBot()
        {

        }

        public string GetQuote(string quote)
        {
            string result = "{0} quote is {1} per share";
            try
            {
                string url = String.Format("https://stooq.com/q/l/?s={0}&f=sd2t2ohlcv&h&e=csv", quote);

                using (WebClient client = new WebClient())
                {
                    string csv = client.DownloadString(url);

                    string line = csv.Split('\n')[1];
                    string price = line.Split(',')[6];

                    result = String.Format(result, quote, price);
                }
            }
            catch (Exception e)
            {
                result = "Cannot get quote for " + quote;
            }
            return result;
        }
    }
}
