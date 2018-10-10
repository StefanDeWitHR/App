using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public  class HttpManager : IHttpManager
    {
        //public static string Username;
        //public static string Password;
        public  string BasePath = "https://servicemodule.propertynl.com/api/export/";
        //GetRSSArticles?newsChannel=NL&Sticky=True

        // public static FetchTokenResponse TokenInfo;
        //   public static SQLiteConnection DB;
        //   public static SQLiteConnection ActiveDB;
        //  public static string Path = UserLoginDetails.SQLitePath;



        public  async Task<string> Post<T>(T DTO, string url)
        {
            try
            {
                string Aurl = BasePath + url;
                HttpClient HC = new HttpClient();

                //if (TokenInfo != null)
                //{
                //    HC.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenInfo.access_token);
                //}
                string Params = JsonConvert.SerializeObject(DTO);
                StringContent S = new StringContent(Params, Encoding.UTF8, "application/json");

                HttpResponseMessage HR = await HC.PostAsync(Aurl, S);

                string LResult = await HR.Content.ReadAsStringAsync();

                int statuscode = Convert.ToInt32(HR.StatusCode);

                return LResult;
            }
            catch (Exception E)
            {
                throw E;
            }
        }

        public  async Task<T> Get<T>(string url)
        {
            try
            {
                string FullUrl = BasePath + url;

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response =  client.GetAsync(FullUrl).Result ;

                string LResult = await response.Content.ReadAsStringAsync();
                T Result = JsonConvert.DeserializeObject<T>(LResult);

                int statuscode = Convert.ToInt32(response.StatusCode);

                return Result;
            }
            catch (Exception E)
            {
                throw E;
            }
        }
       
        public  async Task<bool> Put<T>(T DTO, string url)
        {
            bool LResult = false;

            string FullUrl = BasePath + url;

            try
            {
                HttpClient HC = new HttpClient();

                //if (TokenInfo != null)
                //{
                //    HC.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenInfo.access_token);
                //}
                string Params = JsonConvert.SerializeObject(DTO);
                StringContent S = new StringContent(Params, Encoding.UTF8, "application/json");

                HttpResponseMessage HR = await HC.PutAsync(FullUrl, S);

                string result = await HR.Content.ReadAsStringAsync();
                LResult = (result != "");

                int statuscode = Convert.ToInt32(HR.StatusCode);

                return LResult;
            }
            catch (Exception E)
            {
                throw E;
            }
        }


    }
}

