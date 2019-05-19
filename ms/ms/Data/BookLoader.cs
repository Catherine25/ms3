using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;

namespace ms.Data
{
    static class BookLoader
    {
        public static ObservableCollection<Book> result;

        const string url =
            "http://ec2-18-130-203-173.eu-west-2.compute.amazonaws.com/ms.json";

        public static async void loadData()
        {
            result = null;

            try
            {
                HttpClient httpClient = new HttpClient
                {
                    BaseAddress = new Uri(url)
                };

                var response = await httpClient.GetAsync(httpClient.BaseAddress);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                JObject o = JObject.Parse(content);

                var str = o.SelectToken(@"");

                RootObject productsRoot = JsonConvert.DeserializeObject<RootObject>(content);

                result = productsRoot.books;
            }
            catch
            {
                result = null;
            }
        }
    }

    public class RootObject
    {
        public ObservableCollection<Book> books;
    }
}
