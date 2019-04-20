using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
namespace RedlineSampleCsharpcodeforapicall
{
    public class Class1 
    {
         String response = "";

     

        public string Response { get => response; set => response = value; }

        private X509Certificate2 GetMyCert()
        {
            string certThumbprint = "77d16956df35292aae4dd65ee009497cc4503017";
            X509Certificate2 cert = null;

            // Load the certificate
            var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection certCollection = store.Certificates.Find
            (
                X509FindType.FindByThumbprint,
                certThumbprint,
                false    // Including invalid certificates
            );
            if (certCollection.Count > 0)
            {
                cert = certCollection[0];
            }
            // store.close();

            return cert;
        }

        //code
        public void StartRecognitionimageAsync()
        {
            try
            {
                String username = "user0";
                String userpassword = "s1uqUKZFjDlu";
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(username + ":" + userpassword);
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                string url = @"https://yuuvis.io/";



                HttpClient client = new HttpClient();
                HttpClient request = client;
                // Update port # in the following line.
                request.BaseAddress = new Uri(url);

                //request.Credentials = GetCredential();
                String auth = System.Convert.ToBase64String(plainTextBytes);
                request.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", auth);
                request.DefaultRequestHeaders.Add("X-ID-TENANT-NAME", "nyc070");
                var stringContent = new StringContent("X-ID-TENANT-NAME:nyc070");

                // response.EnsureSuccessStatusCode();
                var imageSet = new ImageSet()
                {
                    Name = "Model",
                    Imagesdata = Directory
                .EnumerateFiles(@"C:\Users\jinus\OneDrive\Pictures\")
                .Where(file => new[] { ".jpg", ".png" }.Contains(Path.GetExtension(file)))
                 .ToList()
                };
                foreach (string s in imageSet.Imagesdata)
                    SendImageSet(s, request);
            }
            catch (Exception exception)
            {
                // this.LogError(exception);
            }
        }
        private static bool AllwaysGoodCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors policyErrors)
        {
            return true;
        }
        private void SendImageSet(string imageSet, HttpClient request)
        {
            var multipartContent = new MultipartFormDataContent();
            var tfile = imageSet;
            var justtfile = Path.GetFileNameWithoutExtension(tfile);

            multipartContent.Add(
                new StringContent(Getmetadatafile(justtfile), Encoding.UTF8, "application/json"),
                "data"
                );
            Byte[] bytes = File.ReadAllBytes(tfile);
            String filecontent = Convert.ToBase64String(bytes);






            multipartContent.Add(new ByteArrayContent(bytes, 0, bytes.Length), "cid_thakur_" + justtfile, justtfile);


            var response = request
                .PostAsync("https://yuuvis.io/api/dms/objects", multipartContent)
                .Result;

            var responseContent = response.Content.ReadAsStringAsync().Result;
            //  response.EnsureSuccessStatusCode();
            this.LogError(responseContent);
        }

        private void LogError(string responseContent)
        {
            this.Response = responseContent;
        }

        private CredentialCache GetCredential()
        {
            string url = @"https://yuuvis.io";

            CredentialCache credentialCache = new CredentialCache();
            credentialCache.Add(new System.Uri(url), "Basic", new NetworkCredential("user0", "s1uqUKZFjDlu"));
            return credentialCache;
        }

        private string Getmetadatafile(string filenamedocument)
        {
            string urljson = "{\"objects\": [{\"properties\": {\"enaio:objectTypeId\": {\"value\": \"document\"},\"Name\": {\"value\": \"my document\"}},\"contentStreams\": [{\"cid\": \"cid_thakur_" + filenamedocument + "\"}]}]}";
            return urljson;
        }

        //code
    }
    public class ImageSet
    {
        public string Name { get; set; }

        [JsonIgnore]
        public List<string> Imagesdata { get; set; }
    }
}