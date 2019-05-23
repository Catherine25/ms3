using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace ms.Data
{
    public static class BookLoader
    {
        public static ObservableCollection<Book> result;

        public static string parseToJSON(ObservableCollection<Book> books)
        {
            RootObject rootObject = new RootObject
            {
                list = books
            };

            return JsonConvert.SerializeObject(rootObject);
        }

        public static ObservableCollection<Book> parseToObject(string JSON)
        {
            JObject o = JObject.Parse(JSON);

            var str = o.SelectToken(@"");

            RootObject productsRoot = JsonConvert.DeserializeObject<RootObject>(JSON);

            return productsRoot.list;
        }

        public static async Task<ObservableCollection<Book>> loadDataFromURLAsync(string url)
        {
            result = null;

            try
            {
                HttpClient httpClient = new HttpClient
                {
                    BaseAddress = new Uri(url)
                };

                HttpResponseMessage response = await httpClient.GetAsync(httpClient.BaseAddress);
                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();

                result = parseToObject(content);
            }
            catch
            {
                result = null;
            }

            return result;
        }
    }

    public class RootObject
    {
        public ObservableCollection<Book> list;
    }
}
