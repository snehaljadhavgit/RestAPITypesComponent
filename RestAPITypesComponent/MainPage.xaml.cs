using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Xamarin.Forms;

namespace RestAPITypesComponent
{
    public partial class MainPage : ContentPage
    {
		WebClient web;
        string strUriSecured = "https://jsonplaceholder.typicode.com/posts";
		string strURLSecured2 = "https://api.androidhive.info/contacts/";
        public MainPage()
        {
            InitializeComponent();


            //Using Webclient
			var userInfo = fnDownloadString(strURLSecured2);

            //Using HttpWebResponseMethod
			HttpWebResponseMethod();

            //Using RestSharp nuget package
			RestSharpMethod();


			//Get JSOn from URL
			GetJsonFromURLmethod();
        }

		private void GetJsonFromURLmethod()
		{
			var response = strURLSecured.Get(requestFilter: webReq =>
            {
                webReq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
            });

          
		}

		private void RestSharpMethod()
		{

			var client = new RestClient(strURLSecured2);

            IRestResponse response = client.Execute(new RestRequest());

           // var releases = JArray.Parse(response.Content);
		}

		private void HttpWebResponseMethod()
		{
         
		        var request = (HttpWebRequest)WebRequest.Create("https://jsonplaceholder.typicode.com/posts");

                request.Method = "GET";
                //request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
                request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

                var response = (HttpWebResponse)request.GetResponse();

                string content = string.Empty;
                using (var stream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream))
                    {
                        content = sr.ReadToEnd();
                    }
                }

               // var releases = JArray.Parse(content);
		}

		async Task<string> fnDownloadString(string strUri)         {             var webclient = new WebClient();             string strResultData;             try             {                 strResultData = await webclient.DownloadStringTaskAsync(new Uri(strUri));                 Console.WriteLine(strResultData);             }             catch             {                 strResultData = "Exception";
                Console.WriteLine(strResultData);             }             finally             {                 if (webclient != null)                 {                     webclient.Dispose();                     webclient = null;                 }             }             return strResultData;         }     }
}
