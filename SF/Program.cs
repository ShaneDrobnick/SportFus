using System;
using System.Threading.Tasks;

namespace SF
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Started");

            //Would not have this hardcoded, typically would pull from DB  
            //you could have it as console argument but key would be annoying
            //But normally would not hardcode these 3
            string fileName = "output.csv";
            string APIKey = "j1zHbAwDsYNo4sR9FpInRVzIX8698p9JxomI";
         
            string URL = "https://api.transport.nsw.gov.au/v1/live/cameras";

            await RunAsync(fileName, APIKey, URL);

        }

        private static async Task RunAsync(string filename, string APIKey, string url)
        {
            ImportCameraData camData = new ImportCameraData(APIKey, url);
            bool response = false;

            Console.WriteLine("Getting Live Traffic Cam data");
            var TrafficCameras = await camData.GetTrafficCameraData();

            if ( TrafficCameras.Features != null)
            {
                ExportCameraData expData = new ExportCameraData(TrafficCameras, filename);
                response = await expData.GenerateCSV();
            }

            if(response)
            {
                Console.WriteLine("Completed");
            } 
            else
            {
                Console.WriteLine("Failed - Data has not been written to file!");
            }

        }

    }
}
