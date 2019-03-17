using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MaxGGLoL.API
{
    public class LeagueApi
    {

        private string ApiKey { get; set; }
        private string SummonerRegion { get; set; }

        public LeagueApi(string summonerRegion)
        {
            this.SummonerRegion = summonerRegion;
            ApiKey = getApiKey("Api.txt");
        }

        public string getApiKey(string path)
        {
            StreamReader streamReader = new StreamReader(path);
            return streamReader.ReadToEnd();
        }

        protected string getApiUri(string path)
        {
            return "https://" + SummonerRegion + ".api.riotgames.com/lol/" + path + "?api_key=" + ApiKey;
        }

        protected HttpResponseMessage GET(string URL)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync(URL);
                result.Wait();

                return result.Result;
            }
        }
    }
}
