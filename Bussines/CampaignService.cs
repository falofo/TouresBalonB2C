using Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bussines
{
    public class CampaignService : ServiceUtil
    {

        public static Campaign buscarCampaignId(int id)
        {
            try
            {
                ServiceResponse srCampaign = consumirServicio("GET", Constants.URL_PRODUCTOS+"campaign/Complete/byID/" + id, null);
                if (srCampaign.code.Equals(HttpStatusCode.OK))
                {
                    JObject jCampaign = JObject.Parse(srCampaign.content);
                    Campaign campaign = jCampaign.ToObject<Campaign>();

                    return campaign;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public static List<Campaign> buscarCampaign()
        {
            try
            {
                ServiceResponse srCampaign = consumirServicio("GET", Constants.URL_PRODUCTOS+"campaign/active/0/4", null);
                if (srCampaign.code.Equals(HttpStatusCode.OK))
                {
                    JObject jCampaign = JObject.Parse(srCampaign.content);
                    IList<JToken> results = jCampaign["collectionCampaigns"].Children().ToList();

                    List<Campaign> Campaigns = new List<Campaign>();
                    foreach (JToken result in results)
                    {
                        Campaign searchResult = result.ToObject<Campaign>();
                        Campaigns.Add(searchResult);
                    }
                    return Campaigns;
                }
                else
                {
                    return null;
                }

            }
            catch
            {
                return null;
            }
        }
    }
}
