using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace kalkulator
{
    class CurrencyManager
    {
        Dictionary<string, ConvertionData> data;
        HashSet<string> currencies;
        public static Host[] hosts;

        public CurrencyManager()
        {
            data = new Dictionary<string, ConvertionData>();
            currencies = new HashSet<string>();
            currencies.AddRange(File.ReadAllLines("currencies.txt"));
        }
        static CurrencyManager()
        {
            hosts = new Host[]
            {
                new Host_FreeCurrencyConverterApi()
            };
        }


        public async Task<double?> GetFactor(string from, string to)
        {
            if(!currencies.Contains(from) )
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
                return value;
            }
            else
            {
                foreach (Host h in hosts.OrderBy(x => x.order))
                {
                    //try
                    {
                        if (h.availableFromTo)
                        {
                            ConvertionData convertion = await h.GetFromTo(from, to);
                            AddEntry(convertion);
                            value = convertion.value;
                        }
                        else if (h.avaivalbeValue) // to pewnie źle. dodać wyszukiwanie połączeń i co jak podstawą nie jest USD
                        {
                            ConvertionData convertionFrom = await h.GetValue(from);
                            ConvertionData convertionTo = await h.GetValue(to);
                            AddEntry(convertionFrom);
                            AddEntry(convertionTo);
                            value = convertionFrom.value / convertionTo.value;
                        }
                        else if (h.avaivalbeAllValues)
                        {
                            Dictionary<string, ConvertionData> newData = await h.GetAll();                         
                            foreach (var c in newData.Values)
                            {
                                AddEntry(c);
                            }
                            value = TryGetFromData(from, to);

                            return value.Value;
                        }
                        else throw new NotImplementedException("Usless host???");
                        return value;
                    }
                    //catch(Exception e)
                    //{
                    //    System.Windows.Forms.MessageBox.Show(e.Message, "Calculator");
                    //}
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
            if(data.ContainsKey(convertion.from + '-' + convertion.to))
            {
                data.Remove(convertion.from + '-' + convertion.to);
            }
            if (data.ContainsKey(convertion.to + '-' + convertion.from))
            {
                data.Remove(convertion.to + '-' + convertion.from);
            }
            data.Add(convertion.from + '-' + convertion.to, convertion);
        }

        public enum UpdateHosts
        {
            FreeCurrencyConvertAPICom
        }
        public abstract class Host
        {
            public abstract string name { get; }
            public abstract bool availableFromTo { get; }
            public abstract bool avaivalbeValue { get; }
            public abstract bool avaivalbeAllValues { get; }
            public int order = 0;

            public abstract Task<ConvertionData> GetFromTo(string from, string to);
            public abstract Task<ConvertionData> GetValue(string of);
            public abstract Task<Dictionary<string, ConvertionData>> GetAll();
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
            public override bool availableFromTo => true;
            public override bool avaivalbeValue => false;
            public override bool avaivalbeAllValues => false;


            public override async Task<ConvertionData> GetFromTo(string from, string to)
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
                                if (jsonReader.TokenType == JsonToken.PropertyName && (string)jsonReader.Value == from+'_'+to)
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

            public override Task<ConvertionData> GetValue(string of)
            {
                throw new NotImplementedException();
            }

            public override Task<Dictionary<string, ConvertionData>> GetAll()
            {
                throw new NotImplementedException();
            }
        }
    }
}