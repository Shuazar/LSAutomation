using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utilities.HttpRequest
{
    public class RequestResponse
    {
        public  string Url { get; set; }
        public RequestResponse(string url)
        {
            Url = url;
        }

        
        public async Task<string> GetResponse()
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(Url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);             
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return "";

        }
    }
}

