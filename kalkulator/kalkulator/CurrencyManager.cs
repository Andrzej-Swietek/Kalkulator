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
        public static Host[] hosts;

        public CurrencyManager()
        {
            data = new Dictionary<string, ConvertionData>();
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
            double? value = TryGetFromData(from, to);
            if (value.HasValue)
            {
                return value;
            }
            else
            {
                foreach (Host h in hosts.OrderBy(x => x.order))
                {
                    try
                    {
                        if (h.availableFromTo)
                        {
                            ConvertionData convertion = await h.GetFromTo(from, to);
                            data.Add(from, convertion);
                            value = convertion.value;
                        }
                        else if (h.avaivalbeValue) // to pewnie źle. dodać wyszukiwanie połączeń i co jak podstawą nie jest USD
                        {
                            ConvertionData convertionFrom = await h.GetValue(from);
                            ConvertionData convertionTo = await h.GetValue(to);
                            data.Add(from, convertionFrom);
                            data.Add(to, convertionTo);
                            value = convertionFrom.value / convertionTo.value;
                        }
                        else if (h.avaivalbeAllValues)
                        {
                            Dictionary<string, ConvertionData> newData = await h.GetAll();
                            foreach (var c in data.Where(d => newData.ContainsKey(d.Value.from + '-' + d.Value.to) ||
                                                         newData.ContainsKey(d.Value.to + '-' + d.Value.from) ||
                                                         newData.ContainsKey(d.Value.from) ||
                                                         newData.ContainsKey(d.Value.to)).ToList())
                            {
                                data.Remove(c.Key);
                            }
                            foreach (var c in newData)
                            {
                                data.Add(c.Key, c.Value);
                            }
                            value = TryGetFromData(from, to);

                            return value.Value;
                        }
                        else throw new NotImplementedException("Usless host???");
                        return value;
                    }
                    catch(Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show(e.Message, "Calculator");
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
            public int order;

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
                            while(jsonReader.Path != from + '_' + to)
                            {
                                double? v = jsonReader.ReadAsDouble();
                                if (!v.HasValue) throw new Exception("Couldn't read value");
                                return new ConvertionData(from, to, v.Value, DateTime.Now);
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