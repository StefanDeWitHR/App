using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public static partial class pasAPI
    {
        public static string BasePath;
        public static string Username;
        public static string Password;
        public static string ClientID;


      // public static FetchTokenResponse TokenInfo;
      //   public static SQLiteConnection DB;
      //   public static SQLiteConnection ActiveDB;
      //  public static string Path = UserLoginDetails.SQLitePath;

        public static void Init()
        {
            BasePath = "";  // TODO
            //Username = "admin";
            //Password = "adminpass";
            ClientID =  "API_CLIENT";
        }

        //// get token
        //public static void GetToken()
        //{
        //    try
        //    {
        //        string LParams = string.Format("grant_type=password&username={0}&password={1}&client_id={2}", Username, Password, ClientID);

        //        var LResult = Task.Run<string>(() => HTTPPost("PostFetchToken", LParams)).Result;
        //        if (LResult == "404")
        //        {
        //            ApplicationSettings.api = Convert.ToInt32(LResult);
        //        }
        //        else
        //        {
        //            if (LResult.ToUpper().Contains("ERROR"))
        //            {
        //                UserLoginDetails.LoginError = "IsError";
        //            }

        //            FetchTokenResponse FR = JsonConvert.DeserializeObject<FetchTokenResponse>(LResult);
        //            TokenInfo = FR;
        //        }
        //    }
        //    catch (Exception E)
        //    {
        //        TokenInfo = null;
        //        throw E;
        //    }
        //}

        // overload 
        //public static async Task<string> Post<T>(T DTO, string url)
        //{
        //    return await Post<T>(DTO, url);
        //}

        public static async Task<string> Post<T>(T DTO, string url)
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

        public static async Task<T> Get<T>(string url)
        {
            try
            {
                string FullUrl = BasePath + url;

                HttpClient HC = new HttpClient();

                //if (TokenInfo != null)
                //{
                //    HC.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenInfo.access_token);
                //}

                HttpResponseMessage HR = await HC.GetAsync(FullUrl);

                string LResult = await HR.Content.ReadAsStringAsync();
                T Result = JsonConvert.DeserializeObject<T>(LResult);

                int statuscode = Convert.ToInt32(HR.StatusCode);

                return Result;
            }
            catch (Exception E)
            {
                throw E;
            }
        }
       
        public static async Task<bool> Put<T>(T DTO, string url)
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

