using SF.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SF
{
    public class ExportCameraData : IExportCameraData
    {
        private readonly TrafficCameras TrafficCameras;
        private readonly string FileName; 
        public ExportCameraData(TrafficCameras trafficCameras, string filename)
        {
            TrafficCameras = trafficCameras;
            FileName = filename;
        }

        public async Task<bool> GenerateCSV(){

            Console.WriteLine("Formatting Data for export");

            int idLength = 0;
            int titleLength = 0;
            int regionLength = 0;
            int directionLength = 0;
            int viewLength = 0;

            List<Features> cameras = new List<Features>();

            //getting the biggest length of each column
            foreach (var camera in TrafficCameras.Features)
            {
                if (camera.Id.Length > idLength)
                    idLength = camera.Id.Length;

                if (camera.Properties.Title.Length > titleLength)
                    titleLength = camera.Properties.Title.Length;

                if (camera.Properties.Region.Length > regionLength)
                    regionLength = camera.Properties.Region.Length;

                if (camera.Properties.Direction.Length > directionLength)
                    directionLength = camera.Properties.Direction.Length;

                if (camera.Properties.View.Length > viewLength)
                    viewLength = camera.Properties.View.Length;
            }

            //Padding added so the File is 'flat file format'
            foreach (var camera in TrafficCameras.Features)
            {
                camera.Id = camera.Id.PadRight(idLength, ' ');
                camera.Properties.Title = camera.Properties.Title.PadRight(titleLength, ' ');
                camera.Properties.Region = camera.Properties.Region.PadRight(regionLength, ' ');
                camera.Properties.Direction = camera.Properties.Direction.PadRight(directionLength, ' ');
                camera.Properties.View = camera.Properties.View.PadRight(viewLength, ' ');

                cameras.Add(camera);
            }

            var writeResponse = await WriteCSV(cameras);

            return writeResponse;
        }

        private async Task<bool> WriteCSV(List<Features> cameras)
        {
            Console.WriteLine("Writing to file " + FileName); 
            try
            {
                using (StreamWriter DestinationWriter = File.CreateText(FileName))
                {
                    foreach (var prop in cameras)
                    {
                        string line = string.Empty;
                        line = prop.Id + ";" + prop.Properties.Title + ";" + prop.Properties.Region + ";" + prop.Properties.Direction + ";" + prop.Properties.View;
                        await DestinationWriter.WriteLineAsync(line);
                    }

                }
            } catch (Exception ex)
            {
                Console.WriteLine("Error writing file");
                Console.WriteLine("Details - " + ex);
                return false;
            }


            return true;
        }
    }
}
