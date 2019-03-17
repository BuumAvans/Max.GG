using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxGGLoL.Model;
using Newtonsoft.Json;

namespace MaxGGLoL.API
{
    public class Summoner : LeagueApi
    {
        public Summoner(string region) : base(region)
        {

        }

        public SummonerDTO GetSummoner(string summonerName)
        {
            string path = "summoner/V4/summoners/by-name/" + summonerName;

            var response = GET(getApiUri(path));

            string content = response.Content.ReadAsStringAsync().Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<SummonerDTO>(content);
            }
            else
            {
                return null;
            }

        }
    }
}
 