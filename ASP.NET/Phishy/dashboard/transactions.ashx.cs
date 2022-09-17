using Newtonsoft.Json;
using Phishy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace Phishy
{
    /// <summary>
    /// Summary description for transactions
    /// </summary>
    public class transactions : HttpTaskAsyncHandler, IRequiresSessionState
    {
        public class DataTablesAjaxResponse
        {
            public uint draw { get; set; }
            public int recordsTotal { get; set; }
            public int recordsFiltered { get; set; }
            public object data { get; set; }
            public string error { get; set; }
        }


        public override async Task ProcessRequestAsync(HttpContext context)
        {
            PhishyAPI fidorApi = (PhishyAPI)context.Session["PhishyAPI"];
            if (fidorApi != null)
            {
                string uniqueId = context.Request.QueryString["draw"];
                uint start = Convert.ToUInt32(context.Request.QueryString["start"]);
                uint length = Convert.ToUInt32(context.Request.QueryString["length"]);

                HttpResponseMessage response = new HttpResponseMessage();
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.fidor.de; version=1, */*");
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + PhishyAPI.accessToken);

                FormUrlEncodedContent content = new FormUrlEncodedContent(new Dictionary<string, string>()
                {
                    { "page", (start / length  + 1).ToString() },
                    { "per_page", length.ToString() }
                }); ;

                UriBuilder builder = new UriBuilder
                {
                    Scheme = Uri.UriSchemeHttps,
                    Port = -1,
                    Host = "api.np.sandbox.fidor.com",
                    Path = "internal_transfers",
                    Query = content.ReadAsStringAsync().Result
                };

                Uri uri = new Uri(builder.ToString());
                response = await httpClient.GetAsync(uri);
                string responseString = await response.Content.ReadAsStringAsync();

                DataTablesAjaxResponse dtResponse = new DataTablesAjaxResponse();
                dtResponse.draw = Convert.ToUInt32(uniqueId);
                dtResponse.recordsFiltered = 0;
                dtResponse.recordsTotal = 0;
                dtResponse.data = new String[0];
                dtResponse.error = null;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    TransactionRecordContainer xferResponse = JsonConvert.DeserializeObject<TransactionRecordContainer>(responseString);
                    dtResponse.recordsTotal = xferResponse.collection.total_entries;
                    dtResponse.recordsFiltered = xferResponse.collection.total_entries;
                    dtResponse.data = xferResponse.data;
                }
                else
                {
                    dtResponse.error = "Error processing request!";
                }

                string json = JsonConvert.SerializeObject(dtResponse);

                context.Response.ContentType = "application/json";
                context.Response.Write(json);
            }
            else
            {
                throw new HttpException(401, "Not logged in");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}