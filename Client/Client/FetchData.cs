using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Client
{
    internal class FetchData
    {
        private string _url {  get; set; }

        public FetchData(string url) 
        {
            _url = url;
        }

        public async Task<string> FetchDataFromApi()
        {
            using (HttpClient  client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage responce = await client.GetAsync(_url);
                    responce.EnsureSuccessStatusCode();
                    string responceData = await responce.Content.ReadAsStringAsync();
                    return responceData;
                }
                catch (Exception ex)
                {
                    return $"Error: {ex.Message}";
                }
            }
        }
    }
}
