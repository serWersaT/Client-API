using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Net;

namespace Client
{
    class HttpClass
    {
        public string GetTest(string kod)
        {
            try
            {
                string url = "http://localhost:38126/api/values/" + kod;
                HttpWebRequest request =
                (HttpWebRequest)WebRequest.Create(url);

                request.Method = "GET";
                request.Accept = "application/json";
                request.UserAgent = "Mozilla/5.0 ....";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                StringBuilder output = new StringBuilder();
                output.Append(reader.ReadToEnd());
                response.Close();
                string rezult = output.ToString();
                rezult = rezult.Replace("\r\n", " ");
                return rezult;
            }
            catch
            {
                return "Нет связи с сервером";
            }
        }

        private static readonly HttpClient client = new HttpClient();
        public async void PostTest(string text)
        {
            var values = new Dictionary<string, string>
            {
                { "test", text }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://localhost:38126/api/values", content);

            var responseString = await response.Content.ReadAsStringAsync();

        }


        public void MessageUpdate(int stroka, string str)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create("http://localhost:38126/api/values/" + stroka.ToString());
            req.Method = "PUT";
            req.Timeout = 50000;
            req.ContentType = "application/x-www-form-urlencoded";
            byte[] sentData = Encoding.GetEncoding(1251).GetBytes(str);
            req.ContentLength = sentData.Length;
            System.IO.Stream sendStream = req.GetRequestStream();
            sendStream.Write(sentData, 0, sentData.Length);
            sendStream.Close();

            System.Net.WebResponse res = req.GetResponse();
        }

        public void MessageDelete(int id)
        {
            string url = "http://localhost:38126/api/values/" + id.ToString();
            HttpWebRequest request =
            (HttpWebRequest)WebRequest.Create(url);

            request.Method = "DELETE";
            request.Accept = "application/json";
            request.UserAgent = "Mozilla/5.0 ....";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            StringBuilder output = new StringBuilder();
            output.Append(reader.ReadToEnd());
            response.Close();
        }

    }
}
