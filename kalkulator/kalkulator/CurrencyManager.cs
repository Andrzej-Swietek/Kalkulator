using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Xml;
using Newtonsoft.Json;

namespace kalkulator
{
    class CurrencyManager
    {
        Dictionary<string, ConvertionData> data;
        HashSet<string> currencies;

        Host_FreeCurrencyConverterApi host_FreeCurrencyConverterApi;
        Host_EuropeanCentralBank host_EuropeanCentralBank;

        public CurrencyManager()
        {
            data = new Dictionary<string, ConvertionData>();
            currencies = new HashSet<string>();
            currencies.AddRange(File.ReadAllLines("currencies.txt"));

            host_FreeCurrencyConverterApi = new Host_FreeCurrencyConverterApi();
            host_EuropeanCentralBank = new Host_EuropeanCentralBank();
        }


        public async Task<double?> Convert(string from, string to, double amount)
        {
            if (!currencies.Contains(from))
            {
                throw new Exception("No currency: " + from);
            }
            if (!currencies.Contains(to))
            {
                throw new Exception("No currency: " + to);
            }

            double? value = TryGetFromData(from, to);
            if (value.HasValue)
            {
                return value * amount;
            }
            else
            {
                if (host_FreeCurrencyConverterApi.aviableCurrencies.Contains(from) && host_FreeCurrencyConverterApi.aviableCurrencies.Contains(to))
                {
                    try
                    {
                        ConvertionData convertion = await FreeCurrencyConverterApi_GetFromTo(from, to);
                        AddEntry(convertion);
                        value = convertion.value;
                        return value * amount;
                    }
                    catch (Exception e)
                    {

                    }
                }

                if (host_EuropeanCentralBank.aviableCurrencies.Contains(from) && host_EuropeanCentralBank.aviableCurrencies.Contains(to))
                {
                    try
                    {
                        Dictionary<string, ConvertionData> newData = await EuropeanCentralBank_GetAll();
                        foreach (var c in newData.Values)
                        {
                            AddEntry(c);
                        }
                        value = TryGetFromData(from, to);

                        return value.Value * amount;
                    }
                    catch (Exception e)
                    {

                    }
                }

                return null;           
            }
        }

        double? TryGetFromData(string from, string to)
        {
            if (data.ContainsKey(from + '-' + to))
            {
                return data[from + '-' + to].value;
            }
            else if (data.ContainsKey(to + '-' + from))
            {
                return 1.0 / data[from + '-' + to].value;
            }
            //else if(data.ContainsKey(from + "-USD") && ) //wyszukiwanie połączeń
            //{
            //    data.try
            //}
            else return null;
        }
        void AddEntry(ConvertionData convertion)
        {
            if (data.ContainsKey(convertion.from + '-' + convertion.to))
            {
                data.Remove(convertion.from + '-' + convertion.to);
            }
            if (data.ContainsKey(convertion.to + '-' + convertion.from))
            {
                data.Remove(convertion.to + '-' + convertion.from);
            }
            data.Add(convertion.from + '-' + convertion.to, convertion);
        }


        async Task<ConvertionData> FreeCurrencyConverterApi_GetFromTo(string from, string to)
        {
            WebClient wc = new WebClient();
            string url = string.Format("http://free.currencyconverterapi.com/api/v3/convert?q={0}_{1}&compact=ultra", from, to);
            byte[] data = Encoding.ASCII.GetBytes("{\"PLN_EUR\":0.238389}"); //await wc.DownloadDataTaskAsync(url);
            string textData = Encoding.ASCII.GetString(data);
            using (MemoryStream ms = new MemoryStream(data))
            {
                using (StreamReader sr = new StreamReader(ms))
                {
                    using (JsonTextReader jsonReader = new JsonTextReader(sr))
                    {
                        while (jsonReader.Read())
                        {
                            if (jsonReader.TokenType == JsonToken.PropertyName && (string)jsonReader.Value == from + '_' + to)
                            {
                                //jsonReader.Read();
                                double? v = jsonReader.ReadAsDouble();
                                if (!v.HasValue) throw new Exception("Couldn't read value");
                                return new ConvertionData(from, to, v.Value, DateTime.Now);
                            }
                        }
                        throw new Exception("Couldn't read value");
                    }
                }
            }
        }

        public async Task<Dictionary<string, ConvertionData>> EuropeanCentralBank_GetAll()
        {
            WebClient wc = new WebClient();
            string url = "http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml";
            byte[] data = File.ReadAllBytes(@"C:\users\w\desktop\aaa.txt"); //await wc.DownloadDataTaskAsync(url);
            string textData = Encoding.ASCII.GetString(data);
            Dictionary<string, double> inValues = new Dictionary<string, double>();
            using (MemoryStream ms = new MemoryStream(data))
            {
                XmlReader xmlr = XmlReader.Create(ms);
                while(xmlr.Read())
                {
                    if(xmlr.NodeType == XmlNodeType.Element && xmlr.Name == "Cube")
                    {
                        if(xmlr.AttributeCount == 2)
                        {
                            xmlr.MoveToFirstAttribute();
                            xmlr.ReadAttributeValue();
                            string currency = xmlr.Value;
                            xmlr.MoveToNextAttribute();
                            xmlr.ReadAttributeValue();
                            double value = double.Parse(xmlr.Value.Replace('.',','));
                            inValues.Add(currency, value);
                        }
                    }
                }
            }
            string baseCurrency;
            if (inValues.ContainsKey("USD")) baseCurrency = "USD";
            else if (inValues.ContainsKey("EUR")) baseCurrency = "EUR";
            else baseCurrency = inValues.First().Key;
            double baseCurrencyVal = inValues[baseCurrency];
            Dictionary<string, ConvertionData> outValues = new Dictionary<string, ConvertionData>();
            foreach (var p in inValues)
            {
                if (p.Key != baseCurrency)
                {
                    outValues.Add(p.Key + '-' + baseCurrency, new ConvertionData(p.Key, baseCurrency, baseCurrencyVal / p.Value, DateTime.Now));
                }
            }
            return outValues;
        }

        


        public enum Hosts
        {
            FreeCurrencyConvertAPICom,
            EuropeanCentralBank
        }
        public abstract class Host
        {
            public abstract string name { get; }
           
        }
        public class ConvertionData
        {
            public string from, to;
            public double value;
            public DateTime acquireDate;

            public ConvertionData(string from, string to, double value, DateTime acquireDate)
            {
                this.from = from;
                this.to = to;
                this.value = value;
                this.acquireDate = acquireDate;
            }
        }

        class Host_FreeCurrencyConverterApi : Host
        {
            public override string name => "Free.CurrencyConverterAPI";
            public string[] aviableCurrencies = new string[] {"AED","AFN","ALL","AMD","AOA","ARS","AUD","AWG","AZN","BAM","BBD","BDT","BGN","BHD","BIF","BND","BOB","BRL","BSD","BTN","BWP","BYN","BZD","CAD","CDF","CHF","CLP","CNY","COP","CRC","CUP","CZK","DJF","DKK","DOP","DZD","EGP","ERN","ETB","EUR","FJD","GBP","GEL","GHS","GIP","GMD","GNF","GTQ","GYD","HKD","HNL","HRK","HTG","HUF","IDR","ILS","INR","IQD","IRR","ISK","JMD","JOD","JPY","KES","KGS","KHR","KMF","KPW","KRW","KWD","KYD","KZT","LAK","LBP","LKR","LRD","LSL","LVL","LYD","MAD","MDL","MGA","MKD","MMK","MNT","MOP","MRO","MUR","MVR","MWK","MXN","MYR","MZN","NAD","NGN","NIO","NOK","NPR","NZD","OMR","PAB","PEN","PGK","PHP","PKR","PLN","PYG","QAR","RON","RSD","RUB","RWF","SAR","SBD","SCR","SDG","SEK","SGD","SHP","SLL","SOS","SRD","STD","SYP","SZL","THB","TJS","TMT","TND","TOP","TRY","TTD","TWD","TZS","UAH","UGX","USD","UYU","UZS","VEF","VND","VUV","WST","XAF","XCD","XOF","XPF","YER","ZAR","ZMW" };

        }
        class Host_EuropeanCentralBank : Host
        {
            public override string name => "Europan Central Bank";
            public string[] aviableCurrencies = new string[] {"AUD","BGN","BRL","CAD","CHF","CNY","CZK","GBP","HKD","HRK","HUF","IDR","ILS","INR","ISK","JPY","KRW","MXN","MYR","NOK","NZD","PHP","PLN","RON","RUB","SEK","SGD","THB","TRY","USD","ZAR"};


        }


    }




    //class CurrencyManager
    //{
    //    Dictionary<string, ConvertionData> data;
    //    HashSet<string> currencies;
    //    public static Host[] hosts;

    //    public CurrencyManager()
    //    {
    //        data = new Dictionary<string, ConvertionData>();
    //        currencies = new HashSet<string>();
    //        currencies.AddRange(File.ReadAllLines("currencies.txt"));
    //    }
    //    static CurrencyManager()
    //    {
    //        hosts = new Host[]
    //        {
    //            new Host_FreeCurrencyConverterApi()
    //        };
    //    }


    //    public async Task<double?> GetFactor(string from, string to)
    //    {
    //        if(!currencies.Contains(from) )
    //        {
    //            throw new Exception("No currency: " + from);
    //        }
    //        if (!currencies.Contains(to))
    //        {
    //            throw new Exception("No currency: " + to);
    //        }

    //        double? value = TryGetFromData(from, to);
    //        if (value.HasValue)
    //        {
    //            return value;
    //        }
    //        else
    //        {
    //            foreach (Host h in hosts.OrderBy(x => x.order))
    //            {
    //                //try
    //                {
    //                    if (h.availableFromTo)
    //                    {
    //                        ConvertionData convertion = await h.GetFromTo(from, to);
    //                        AddEntry(convertion);
    //                        value = convertion.value;
    //                    }
    //                    else if (h.avaivalbeValue) // to pewnie źle. dodać wyszukiwanie połączeń i co jak podstawą nie jest USD
    //                    {
    //                        ConvertionData convertionFrom = await h.GetValue(from);
    //                        ConvertionData convertionTo = await h.GetValue(to);
    //                        AddEntry(convertionFrom);
    //                        AddEntry(convertionTo);
    //                        value = convertionFrom.value / convertionTo.value;
    //                    }
    //                    else if (h.avaivalbeAllValues)
    //                    {
    //                        Dictionary<string, ConvertionData> newData = await h.GetAll();                         
    //                        foreach (var c in newData.Values)
    //                        {
    //                            AddEntry(c);
    //                        }
    //                        value = TryGetFromData(from, to);

    //                        return value.Value;
    //                    }
    //                    else throw new NotImplementedException("Usless host???");
    //                    return value;
    //                }
    //                //catch(Exception e)
    //                //{
    //                //    System.Windows.Forms.MessageBox.Show(e.Message, "Calculator");
    //                //}
    //            }
    //            return null;
    //        }
    //    }

    //    double? TryGetFromData(string from, string to)
    //    {
    //        if (data.ContainsKey(from + '-' + to))
    //        {
    //            return data[from + '-' + to].value;
    //        }
    //        else if (data.ContainsKey(to + '-' + from))
    //        {
    //            return 1.0 / data[from + '-' + to].value;
    //        }
    //        //else if(data.ContainsKey(from + "-USD") && ) //wyszukiwanie połączeń
    //        //{
    //        //    data.try
    //        //}
    //        else return null;
    //    }
    //    void AddEntry(ConvertionData convertion)
    //    {
    //        if(data.ContainsKey(convertion.from + '-' + convertion.to))
    //        {
    //            data.Remove(convertion.from + '-' + convertion.to);
    //        }
    //        if (data.ContainsKey(convertion.to + '-' + convertion.from))
    //        {
    //            data.Remove(convertion.to + '-' + convertion.from);
    //        }
    //        data.Add(convertion.from + '-' + convertion.to, convertion);
    //    }

    //    public enum UpdateHosts
    //    {
    //        FreeCurrencyConvertAPICom
    //    }
    //    public abstract class Host
    //    {
    //        public abstract string name { get; }
    //        public abstract bool availableFromTo { get; }
    //        public abstract bool avaivalbeValue { get; }
    //        public abstract bool avaivalbeAllValues { get; }
    //        public int order = 0;

    //        public abstract Task<ConvertionData> GetFromTo(string from, string to);
    //        public abstract Task<ConvertionData> GetValue(string of);
    //        public abstract Task<Dictionary<string, ConvertionData>> GetAll();
    //    }
    //    public class ConvertionData
    //    {
    //        public string from, to;
    //        public double value;
    //        public DateTime acquireDate;

    //        public ConvertionData(string from, string to, double value, DateTime acquireDate)
    //        {
    //            this.from = from;
    //            this.to = to;
    //            this.value = value;
    //            this.acquireDate = acquireDate;
    //        }
    //    }

    //    class Host_FreeCurrencyConverterApi : Host
    //    {
    //        public override string name => "Free.CurrencyConverterAPI";
    //        public override bool availableFromTo
    //        {
    //            get
    //            {
    //                return true;
    //            }
    //        }
    //            // => true;
    //        public override bool avaivalbeValue => false;
    //        public override bool avaivalbeAllValues => false;


    //        public override async Task<ConvertionData> GetFromTo(string from, string to)
    //        {
    //            WebClient wc = new WebClient();
    //            string url = string.Format("http://free.currencyconverterapi.com/api/v3/convert?q={0}_{1}&compact=ultra", from, to);
    //            byte[] data = Encoding.ASCII.GetBytes("{\"PLN_EUR\":0.238389}"); //await wc.DownloadDataTaskAsync(url);
    //            string textData = Encoding.ASCII.GetString(data);
    //            using (MemoryStream ms = new MemoryStream(data))
    //            {
    //                using (StreamReader sr = new StreamReader(ms))
    //                {
    //                    using (JsonTextReader jsonReader = new JsonTextReader(sr))
    //                    {
    //                        while (jsonReader.Read())
    //                        {
    //                            if (jsonReader.TokenType == JsonToken.PropertyName && (string)jsonReader.Value == from+'_'+to)
    //                            {
    //                                //jsonReader.Read();
    //                                double? v = jsonReader.ReadAsDouble();
    //                                if (!v.HasValue) throw new Exception("Couldn't read value");
    //                                return new ConvertionData(from, to, v.Value, DateTime.Now);
    //                            }
    //                        }
    //                        throw new Exception("Couldn't read value");
    //                    }
    //                }
    //            }          
    //        }

    //        public override Task<ConvertionData> GetValue(string of)
    //        {
    //            throw new NotImplementedException();
    //        }

    //        public override Task<Dictionary<string, ConvertionData>> GetAll()
    //        {
    //            throw new NotImplementedException();
    //        }
    //    }
    //}
}