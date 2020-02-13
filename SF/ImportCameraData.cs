using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SF.Model;

namespace SF
{
    public class ImportCameraData : IImportCameraData
    {
        private readonly string APIKey;
        private readonly string URL;
        public ImportCameraData(string apiKey, string url)
        {
            APIKey = apiKey;
            URL = url;
        }

        public async Task<TrafficCameras> GetTrafficCameraData()
        {
            TrafficCameras trafficCameras = new TrafficCameras();

            using var client = new HttpClient();
            try
            {
                client.DefaultRequestHeaders.Add("Authorization", "apikey " + APIKey);
                var response = await client.GetAsync(URL);
                response.EnsureSuccessStatusCode();
                var stringResult = await response.Content.ReadAsStringAsync();
                trafficCameras = JsonConvert.DeserializeObject<TrafficCameras>(stringResult);

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Attempt to GET Data has failed with - " + ex.Message);
                return trafficCameras;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //Typically would add to Error logs 
                return trafficCameras;
            }
            return trafficCameras;
        }
    }
}
